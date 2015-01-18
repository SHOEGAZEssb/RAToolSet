using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using System;

namespace RAToolSet
{
  public partial class RAInformer : Form
  {
    Dictionary<int, string> _consoles = new Dictionary<int, string>();
    Dictionary<int, List<Game>> _gameList = new Dictionary<int, List<Game>>();
    ImageForm _imageForm;

    public RAInformer()
    {
      InitializeComponent();
      getConsolesWorker.RunWorkerAsync();
    }

    //Start the given process and returns all it's output, splitted by '|'
    private string[] GetSplittedProcessOutput(string path, string arguments)
    {
      Process prc = new Process();
      ProcessStartInfo info = new ProcessStartInfo(path, arguments);
      info.UseShellExecute = false;
      info.RedirectStandardOutput = true;
      info.CreateNoWindow = true;
      prc.StartInfo = info;
      prc.Start();

      string[] returnString = prc.StandardOutput.ReadToEnd().Split('|');
      return returnString;
    }

    /// <summary>
    /// Get the complete game list for the specified consoleID and write it to the corresponding list
    /// </summary>
    /// <param name="consoleID">Console ID to get game list for</param>
    private void GetGameList(int consoleID)
    {
      getGameListWorker.RunWorkerAsync(consoleID);
    }

    /// <summary>
    /// Calls the GetGameInfoWorker with the specified game ID.
    /// </summary>
    /// <param name="consoleID">Game ID to get gameInfo for.</param> 
    private void GetGameInfo(int gameID)
    {
      getGameInfoWorker.RunWorkerAsync(gameID);
    }

    /// <summary>
    /// Gets the game info for all given game IDs
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e">Game IDs to get info for</param>
    private void getGameInfoWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
    {
      string idList = e.Argument.ToString();

      string[] gameIDs = idList.Split(' ');

      Invoke(new Action(() =>
      {
        lblProgress.Text = "Getting " + GetGameByID((int)e.Argument).Title + " Game Info";
      }));

      string[] arr = GetSplittedProcessOutput(@"..\..\..\..\GetGameInfoExtended.exe", idList);

      for (int f = 0; f < arr.Length / 19; f++)
      {
        GameInfo gameInfo = new GameInfo(StringToInt(arr[(19 * f)]), arr[(19 * f) + 1], StringToInt(arr[(19 * f) + 2]), StringToInt(arr[(19 * f) + 3]),
                                          arr[(19 * f) + 4], arr[(19 * f) + 5], arr[(19 * f) + 6], arr[(19 * f) + 7], arr[(19 * f) + 8], arr[(19 * f) + 9],
                                          arr[(19 * f) + 10], arr[(19 * f) + 11], arr[(19 * f) + 12], StringToInt(arr[(19 * f) + 13]), arr[(19 * f) + 14],
                                          arr[(19 * f) + 15], StringToInt(arr[(19 * f) + 16]), StringToInt(arr[(19 * f) + 17]), StringToInt(arr[(19 * f) + 18]));

        AddGameInfoToGame(gameInfo, GetGameByID(int.Parse(gameIDs[f])));
        PrintGameInfo(gameInfo);
      }   
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

    private Game GetGameByID(int gameID)
    {
      return GetFullGameList().Where<Game>(i => i.ID == gameID).FirstOrDefault();
    }

    private Game GetGameByName(string name)
    {
      return GetFullGameList().Where<Game>(i => i.Title == name).FirstOrDefault();
    }

    /// <summary>
    /// Combines all game lists from all consoles into one.
    /// </summary>
    /// <returns>Full game list</returns>
    private List<Game> GetFullGameList()
    {
      List<Game> fullList = new List<Game>();

      foreach (KeyValuePair<int, List<Game>> entry in _gameList)
      {
        foreach (Game g in entry.Value)
        {
          fullList.Add(g);
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
    /// Parses a string to an int.
    /// </summary>
    /// <param name="str">String to parse</param>
    /// <returns>Integer parsed from input string, -1 if parsing failed</returns>
    private int StringToInt(string str)
    {
      try
      {
        return int.Parse(str);
      }
      catch
      {
        return -1;
      }
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
      Game g = GetGameByName(comboBox1.SelectedItem.ToString());
      if(g.GameInfo == null)
        GetGameInfo(g.ID);
      else
        PrintGameInfo(g.GameInfo);
    }

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

      Stopwatch w = new Stopwatch();
      w.Start();
      string[] arr = GetSplittedProcessOutput(@"..\..\..\..\GetConsoleIDs.exe", "");
      w.Stop();

      for (int i = 0; i < arr.Length / 2; i++)
      {
        _consoles.Add(StringToInt(arr[(i * 2)]), arr[(i * 2) + 1]);
        Invoke(new Action(() =>
        {
          comboBoxConsole.Items.Add(arr[(i * 2) + 1]);
        }));
      }

      //Initialize GameList Dicitonary
      for (int i = 1; i <= _consoles.Count; i++)
      {
        _gameList.Add(i, new List<Game>());
      }

      Invoke(new Action(() =>
      {
        lblProgress.Text = "Fetched Console Information, Took " + w.ElapsedMilliseconds + " ms";
        comboBoxConsole.Enabled = true;
      }));
    }

    private void comboBoxConsole_SelectedIndexChanged(object sender, EventArgs e)
    {
      comboBox1.Items.Clear();

      if (_gameList[comboBoxConsole.SelectedIndex + 1].Count == 0)
        GetGameList(comboBoxConsole.SelectedIndex + 1);
      else
      {
        foreach (Game g in _gameList[comboBoxConsole.SelectedIndex + 1])
        {
          comboBox1.Items.Add(g.Title);
        }
      }
    }

    /// <summary>
    /// Gets the game list of the specified console ID.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e">Console ID to get game list for.</param>
    private void getGameListWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
    {
      int consoleID = (int)e.Argument;

      Invoke(new Action(() =>
      {
        lblProgress.Text = "Getting " + _consoles[consoleID] + " Game List.";
      }));

      string[] arr = GetSplittedProcessOutput(@"..\..\..\..\GetGameList.exe", consoleID.ToString());
      List<Game> list = _gameList[consoleID];

      for (int i = 0; i < arr.Length / 4; i++)
      {
        list.Add(new Game(arr[4 * i], StringToInt(arr[(4 * i) + 1]), StringToInt(arr[(4 * i) + 2]), arr[(4 * i) + 3]));
      }

      Invoke(new Action(() =>
      {
        lblProgress.Text = "Fetched " + _consoles[consoleID] + " Game List";
        comboBox1.Enabled = true;

        foreach (Game g in list)
        {
          comboBox1.Items.Add(g.Title);
        }
      }));
    }

    private void linklblForumPost_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      if (comboBox1.SelectedItem != null)
      {
        string link = "http://retroachievements.org/viewtopic.php?t=&c=".Replace("t=", "t=" + GetGameByName(comboBox1.SelectedItem.ToString()).GameInfo.ForumTopicID);
        Process.Start(link);
      }
    }

    private void linklblImages_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
    {
      if (comboBox1.SelectedItem != null)
      {
        Game g = GetGameByName(comboBox1.SelectedItem.ToString());
        _imageForm = new ImageForm(g.GameInfo.ImageIcon, g.GameInfo.ImageTitle, g.GameInfo.ImageIngame, g.GameInfo.ImageBoxArt);
        _imageForm.Show();
      }
    }
  }
}