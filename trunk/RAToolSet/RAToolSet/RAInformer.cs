using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using System;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace RAToolSet
{
  public enum APIFunction
  {
    GetConsoleIDs,
    GetGameList,
    GetGameExtended
  }

  public partial class RAInformer : Form
  {
    Dictionary<int, string> _consoles = new Dictionary<int, string>();
    Dictionary<int, List<Game>> _gameList = new Dictionary<int, List<Game>>();
    List<Console> _consoleList = new List<Console>();
    ImageForm _imageForm;

    /// <summary>
    /// Ctor.
    /// </summary>
    public RAInformer()
    {
      InitializeComponent();
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
      var request = WebRequest.Create("http://54.77.113.119/API/API_" + apiFunction.ToString() + ".php?z=coczero&y=AEwHP8tc6G9JaUweJl3zMZq2CRj2uIPV&i=" + argument);
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
    private void PrintGameInfo(GameInfo info)
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
    /// Adds the specified GameInfo to the specified Game
    /// </summary>
    /// <param name="gameInfo">GameInfo to add.</param>
    /// <param name="game">Game to add the game info to.</param>
    private void AddGameInfoToGame(GameInfo gameInfo, Game game)
    {
      game.GameInfo = gameInfo;
    }

    /// <summary>
    /// Downloads the game list for the newly selected console, if not already done.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void comboBoxGame_SelectedIndexChanged(object sender, EventArgs e)
    {
      Game g = GetGameByName(comboBoxGame.SelectedItem.ToString());
      if (g.GameInfo == null)
        FetchGameInfo(g.ID);
      else
      {
        PrintGameInfo(g.GameInfo);

        comboBoxAchievement.Items.Clear();
        foreach (Achievement a in g.GameInfo.Achievements.Values)
        {
          comboBoxAchievement.Items.Add(a.Title);
        }
      }
    }

    #region WorkerMethods

    /// <summary>
    /// Worker to fetch all consoles
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void getConsolesWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
    {
      Invoke(new Action(() =>
      {
        lblProgress.Text = "Getting Console Data";
      }));

      string[] consoles = GetWebRequestString(APIFunction.GetConsoleIDs, "").Split(';');

      Invoke(new Action(() =>
      {
        lblProgress.Text = "Fetched Console Information";
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
    /// <param name="sender"></param>
    /// <param name="e">Game ID to get info for</param>
    private void getGameInfoWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
    {
      int gameID = (int)e.Argument;

      Invoke(new Action(() =>
      {
        lblProgress.Text = "Getting " + GetGameByID(gameID).Title + " Game Info";
      }));

      string info = GetWebRequestString(APIFunction.GetGameExtended, gameID.ToString());

      Invoke(new Action(() =>
      {
        lblProgress.Text = "Fetched " + GetGameByID(gameID).Title + " Game Info";
      }));

      GameInfo g = JsonConvert.DeserializeObject<GameInfo>(info);
      AddGameInfoToGame(g, GetGameByID(gameID));
      PrintGameInfo(g);

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
    /// <param name="sender"></param>
    /// <param name="e">Console ID to get game list for.</param>
    private void getGameListWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
    {
      Console c = GetConsoleByID((int)e.Argument);

      Invoke(new Action(() =>
      {
        lblProgress.Text = "Getting " + c.Name + " Game List.";
      }));

      string json = GetWebRequestString(APIFunction.GetGameList, c.ID.ToString());

      Invoke(new Action(() =>
      {
        lblProgress.Text = "Fetched " + c.Name + " Game List";
      }));

      string[] games = json.Split(';');
      foreach (string game in games)
      {
        c.Games.Add(JsonConvert.DeserializeObject<Game>(game));
      }

      Invoke(new Action(() =>
      {
        comboBoxGame.Enabled = true;

        foreach (Game g in c.Games)
        {
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
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void linklblForumPost_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      if (comboBoxGame.SelectedItem != null)
      {
        Game g = GetGameByName(comboBoxGame.SelectedItem.ToString());
        if (g.GameInfo != null)
        {
          string link = "http://retroachievements.org/viewtopic.php?t=&c=".Replace("t=", "t=" + g.GameInfo.ForumTopicID);
          Process.Start(link);
        }
      }
    }

    /// <summary>
    /// Opens the ImageForm with the images of the currently displayed game.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void linklblImages_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      if (comboBoxGame.SelectedItem != null)
      {
        Game g = GetGameByName(comboBoxGame.SelectedItem.ToString());
        if (g.GameInfo != null)
        {
          _imageForm = new ImageForm(g.GameInfo);
          _imageForm.Show();
        }
      }
    }
  }
}