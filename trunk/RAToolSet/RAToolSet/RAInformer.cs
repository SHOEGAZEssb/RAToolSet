using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using System;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Threading;

namespace RAToolSet
{
  public enum APIFunction
  {
    GetConsoleIDs,
    GetGameList,
    GetGameExtended,
    GetAchievementCount
  }

  public partial class RAInformer : Form
  {
    private Dictionary<int, string> _consoles = new Dictionary<int, string>();
    private Dictionary<int, List<Game>> _gameList = new Dictionary<int, List<Game>>();
    private List<Console> _consoleList = new List<Console>();
    private Stopwatch _watch = new Stopwatch();
    private Database _database = new Database();
    private List<int> _fullyFetchedGames = new List<int>();

    /// <summary>
    /// Ctor.
    /// </summary>
    public RAInformer()
    {
      InitializeComponent();
      if(RAToolSet.Properties.Settings.Default.Username == "" || RAToolSet.Properties.Settings.Default.APIKey == "")
      {
        OptionsForm o = new OptionsForm();
        o.ShowDialog();
      }

      getConsolesWorker.RunWorkerAsync();
    }

    /// <summary>
    /// Gets the data via a web request with the specified APIFunction and argument.
    /// </summary>
    /// <param name="apiFunction">APIFunction to call.</param>
    /// <param name="argument">Argument to pass.</param>
    /// <returns>Response from the WebRequest.</returns>
    private string GetWebRequestString(APIFunction apiFunction, string argument)
    {
      var request = WebRequest.Create("http://retroachievements.org/API/API_" + apiFunction + ".php?z=" + RAToolSet.Properties.Settings.Default.Username + "&y=" + RAToolSet.Properties.Settings.Default.APIKey + "&i=" + argument);
      request.Proxy = new WebProxy();
      string text;
      var response = (HttpWebResponse)request.GetResponse();
      
      using (var sr = new StreamReader(response.GetResponseStream()))
      {
        text = sr.ReadToEnd();
      }

      text = text.Replace("[", "").Replace("]", "");

      if (apiFunction != APIFunction.GetGameExtended)
        text = text.Replace("},", "};");

      return text;
    }

    /// <summary>
    /// Updates the labels with the currently selected game's info
    /// </summary>
    /// <param name="info">GameInfo to display</param>
    private void PrintGameInfo(Game info)
    {
      Invoke(new Action(() =>
      {
        lblIDContent.Text = info.ID.ToString();
        lblTitleContent.Text = info.Title;
        lblFlagsContent.Text = info.Flags;
        lblPublisherContent.Text = info.Publisher;
        lblDeveloperContent.Text = info.Developer;
        lblGenreContent.Text = info.Genre;
        lblReleaseContent.Text = info.Released;
      }));
    }

    /// <summary>
    /// Gets the game with the specified id from the full game list.
    /// </summary>
    /// <param name="id">ID to get game for.</param>
    /// <returns>Game with the specified id</returns>
    private Game GetGameByID(int id)
    {
      return GetFullGameList().Where<Game>(i => i.ID == id).FirstOrDefault();
    }

    /// <summary>
    /// Gets the game with the specified name from the full game list.
    /// </summary>
    /// <param name="name">Name to get game for.</param>
    /// <returns>Game with the specified name.</returns>
    private Game GetGameByName(string name)
    {
      return GetFullGameList().Where<Game>(i => i.Title == name).FirstOrDefault();
    }

    /// <summary>
    /// Gets the console with the specified console id from the console list.
    /// </summary>
    /// <param name="id">ID to get console for.</param>
    /// <returns>Console with the specified id.</returns>
    private Console GetConsoleByID(int id)
    {
      return _consoleList.Where<Console>(i => i.ID == id).FirstOrDefault();
    }

    /// <summary>
    /// Calls the GetGameInfoWorker with the specified game ID.
    /// </summary>
    /// <param name="consoleID">Game ID to get gameInfo for.</param> 
    private void FetchGameInfo(int gameID)
    {
      getGameInfoWorker.RunWorkerAsync(gameID);
    }

    /// <summary>
    /// Get the complete game list for the specified consoleID and write it to the corresponding list
    /// </summary>
    /// <param name="consoleID">Console ID to get game list for</param>
    private void FetchGameList(int consoleID)
    {
      getGameListWorker.RunWorkerAsync(consoleID);
    }

    /// <summary>
    /// Combines all game lists from all consoles into one.
    /// </summary>
    /// <returns>Full game list</returns>
    private List<Game> GetFullGameList()
    {
      List<Game> fullList = new List<Game>();

      foreach (Console c in _consoleList)
      {
        foreach (Game g in c.Games)
        {
          fullList.Add(g); //TODO: see if .concat is faster
        }
      }

      return fullList;
    }

    /// <summary>
    /// Downloads the game list for the newly selected console, if not already done.
    /// </summary>
    private void comboBoxConsole_SelectedIndexChanged(object sender, EventArgs e)
    {
      comboBoxGame.Items.Clear();
      Console selectedConsole = GetConsoleByID(comboBoxConsole.SelectedIndex + 1);

      if (selectedConsole.Games.Count == 0)
        FetchGameList(selectedConsole.ID);
      else
      {
        foreach (Game g in selectedConsole.Games)
        {
          comboBoxGame.Items.Add(g.Title);
        }

        comboBoxGame.SelectedItem = "";
      }
    }

    /// <summary>
    /// Downloads the game info for the newly selected game, if not already done.
    /// </summary>
    private void comboBoxGame_SelectedIndexChanged(object sender, EventArgs e)
    {
      Game g = GetGameByName(comboBoxGame.SelectedItem.ToString());
      if (!_fullyFetchedGames.Contains(g.ID))
        FetchGameInfo(g.ID);
      else
      {
        PrintGameInfo(g);

        comboBoxAchievement.Items.Clear();
        foreach (Achievement a in g.Achievements.Values)
        {
          comboBoxAchievement.Items.Add(a.Title);
        }
      }
    }

    #region WorkerMethods

    /// <summary>
    /// Worker to fetch all consoles
    /// </summary>
    private void getConsolesWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
    {
      Invoke(new Action(() =>
      {
        lblProgress.Text = "Getting Console Data";
      }));

      _watch.Reset();
      _watch.Start();
      string[] consoles = GetWebRequestString(APIFunction.GetConsoleIDs, "").Split(';');
      _watch.Stop();

      Invoke(new Action(() =>
      {
        lblProgress.Text = "Fetched Console Information, took " + _watch.ElapsedMilliseconds + " milliseconds.";
        comboBoxConsole.Enabled = true;
      }));

      foreach (string console in consoles)
      {
        Console c = JsonConvert.DeserializeObject<Console>(console);
        _consoleList.Add(c);
        Invoke(new Action(() =>
        {
          comboBoxConsole.Items.Add(c.Name);
        }));
      }

      //Initialize GameList Dicitonary
      for (int i = 1; i <= _consoles.Count; i++)
      {
        _gameList.Add(i, new List<Game>());
      }
    }

    /// <summary>
    /// Gets the game info for all given game IDs
    /// </summary>
    /// <param name="e">Game ID to get info for</param>
    private void getGameInfoWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
    {
      int gameID = (int)e.Argument;

      Invoke(new Action(() =>
      {
        lblProgress.Text = "Getting " + GetGameByID(gameID).Title + " Game Info";
      }));

      _watch.Reset();
      _watch.Start();
      string info = GetWebRequestString(APIFunction.GetGameExtended, gameID.ToString());
      _watch.Stop();

      Invoke(new Action(() =>
      {
        lblProgress.Text = "Fetched " + GetGameByID(gameID).Title + " Game Info, took " + _watch.ElapsedMilliseconds + " milliseconds.";
      }));

      Game g = JsonConvert.DeserializeObject<Game>(info);

      //Remove old game with less info and add the new one.
      GetConsoleByID(g.ConsoleID).Games.Remove((Game)GetConsoleByID(g.ConsoleID).Games.Where(i => i.ID == g.ID).FirstOrDefault());
      GetConsoleByID(g.ConsoleID).Games.Add(g);
      PrintGameInfo(g);
      _fullyFetchedGames.Add(g.ID);
      _database.InsertGame(g);

      Invoke(new Action(() =>
      {
        comboBoxAchievement.Items.Clear();
        foreach (Achievement a in g.Achievements.Values)
        {
          comboBoxAchievement.Items.Add(a.Title);
        }
      }));
    }

    /// <summary>
    /// Gets the game list of the specified console ID.
    /// </summary>
    /// <param name="e">Console ID to get game list for.</param>
    private void getGameListWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
    {
      Console c = GetConsoleByID((int)e.Argument);

      Invoke(new Action(() =>
      {
        lblProgress.Text = "Getting " + c.Name + " Game List.";
      }));

      _watch.Reset();
      _watch.Start();
      string json = GetWebRequestString(APIFunction.GetGameList, c.ID.ToString());
      _watch.Stop();

      Invoke(new Action(() =>
      {
        lblProgress.Text = "Fetched " + c.Name + " Game List, took " + _watch.ElapsedMilliseconds + " milliseconds.";
      }));

      string[] games = json.Split(';');
      foreach (string game in games)
      {
        try
        {
          c.Games.Add(JsonConvert.DeserializeObject<Game>(game));
        }
        catch
        {
          //something went wrong with parsing, check game title for ';'
          continue;
        }
      }

      Invoke(new Action(() =>
      {
        comboBoxGame.Enabled = true;

        foreach (Game g in c.Games)
        {
          //only the case if the console has 0 games.
          if (g == null)
            return;

          if (g.Title != null)
            comboBoxGame.Items.Add(g.Title);
          else
            comboBoxGame.Items.Add("!CORRUPTED TITLE!");
        }

        comboBoxGame.SelectedItem = "";
      }));
    }

    #endregion

    /// <summary>
    /// Opens the forum thread of the currently displayed game.
    /// </summary>
    private void linklblForumPost_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      if (comboBoxGame.SelectedItem != null)
      {
        Game g = GetGameByName(comboBoxGame.SelectedItem.ToString());
        if (_fullyFetchedGames.Contains(g.ID))
        {
          string link = "http://retroachievements.org/viewtopic.php?t=&c=".Replace("t=", "t=" + g.ForumTopicID);
          Process.Start(link);
        }
      }
    }

    /// <summary>
    /// Opens the ImageForm with the images of the currently displayed game.
    /// </summary>
    private void linklblImages_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      if (comboBoxGame.SelectedItem != null)
      {
        Game g = GetGameByName(comboBoxGame.SelectedItem.ToString());
        if (_fullyFetchedGames.Contains(g.ID))
        {
          ImageForm imageForm = new ImageForm(g);
          imageForm.Show();
        }
      }
    }

    /// <summary>
    /// Updates the label with the infos from the selected achievement.
    /// </summary>
    private void comboBoxAchievement_SelectedIndexChanged(object sender, EventArgs e)
    {
      Achievement a = GetGameByName(comboBoxGame.SelectedItem.ToString()).Achievements.ElementAt(comboBoxAchievement.SelectedIndex).Value;
      lblAchIDContent.Text = a.ID.ToString();
      lblNumAwardedContent.Text = a.NumAwarded.ToString();
      lblNumAwardedHardcoreContent.Text = a.NumAwardedHardcore.ToString();
      lblAchTitleContent.Text = a.Title;
      lblDescriptionContent.Text = a.Description;
      lblPointsContent.Text = a.Points.ToString();
      lblTrueRatioContent.Text = a.TrueRatio.ToString();
      lblAuthorContent.Text = a.Author;
      lblDateModifiedContent.Text = a.DateModified;
      lblDateCreatedContent.Text = a.DateCreated;
      //memory conditions;
      //date earned
      //date earned hc
    }

    /// <summary>
    /// Opens the RichPresenceForm and shows the rich presence of this game.
    /// </summary>
    private void linkLabelRichPresence_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      if (comboBoxGame.SelectedItem != null)
      {
        Game g = GetGameByName(comboBoxGame.SelectedItem.ToString());
        RichPresenceForm rpForm = new RichPresenceForm(g.RichPresencePatch);
        rpForm.Show();
      }
    }

    private void btnFetchAll_Click(object sender, EventArgs e)
    {
      FetchAllWorker.RunWorkerAsync();
    }

    private void FetchAllWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
    {
      foreach (Console c in _consoleList)
      {
        while (getGameListWorker.IsBusy)
        {
          Thread.Sleep(100);
        }

        getGameListWorker.RunWorkerAsync(c.ID);
      }

      foreach (Console c in _consoleList)
      {
        for (int i = 0; i < c.Games.Count; i++)
        {
          while (getGameInfoWorker.IsBusy)
          {
            Thread.Sleep(1);
          }

          getGameInfoWorker.RunWorkerAsync(c.Games[i].ID);
        }
      }
    }
  }
}