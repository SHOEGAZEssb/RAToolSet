using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using System;

namespace RAToolSet
{
  public partial class Form1 : Form
  {
    Dictionary<int, string> _consoles = new Dictionary<int, string>();
    Dictionary<int, List<Game>> _gameList = new Dictionary<int, List<Game>>();


    public Form1()
    {
      InitializeComponent();
      GetAllData();
    }

    private void InitializeGameLists()
    {
      for (int i = 1; i <= _consoles.Count; i++)
      {
        _gameList.Add(i, new List<Game>());
      }
    }

    private void GetAllData()
    {
      GetConsoles();
      InitializeGameLists();
      GetGameList(4);
      GetGameInfo(4);
    }

    //Start the given process and returns all it's output, splitted by '|'; this should probably be on another thread
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

    // Get's the available Consoles and their corresponding IDs from the RA webapi
    private void GetConsoles()
    {
      string[] arr = GetSplittedProcessOutput(@"..\..\..\..\GetConsoleIDs.exe", "");

      //FUCKING UNSAFE
      for (int i = 0; i < arr.Length / 2; i++)
      {
        _consoles.Add(StringToInt(arr[(i * 2)]), arr[(i * 2) + 1]);
      }

      label1.Text = "Fetched Console IDs";
    }

    //Get the complete game list for the specified consoleID and write it to the corresponding list
    private void GetGameList(int consoleID)
    {
      string[] arr = GetSplittedProcessOutput(@"..\..\..\..\GetGameList.exe", consoleID.ToString());
      List<Game> list = GetGameListByConsoleID(consoleID);

      for (int i = 0; i < arr.Length / 4; i++)
      {
        list.Add(new Game(arr[4 * i], StringToInt(arr[(4 * i) + 1]), StringToInt(arr[(4 * i) + 2]), arr[(4 * i) + 3]));
      }

      label1.Text = "Fetched " + _consoles[consoleID].ToString() + " Game List";

      foreach (Game g in list)
      {
        comboBox1.Items.Add(g.Title);
      }
    }

    private void GetGameInfo(int consoleID)
    {
      getgameInfoWorker.RunWorkerAsync(consoleID);
    }

    // gets the GameInfo for all games of the given console
    private void getgameInfoWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
    {
      List<Game> list = GetGameListByConsoleID((int)e.Argument);

      string gameIDString = "";

      for (int i = 0; i < list.Count; i++)
      {
        gameIDString += list[i].ID;

        if (i != list.Count - 1)
          gameIDString += " ";
      }

      string[] gameIDs = gameIDString.Split(' ');

      Invoke(new Action(() =>
      {
        progressBar1.Maximum = gameIDs.Length;
        progressBar1.Value = 0;
      }));

      foreach (string id in gameIDs)
      {
        string[] arr = GetSplittedProcessOutput(@"..\..\..\..\GetGameInfoExtended.exe", id);


        for (int f = 0; f < arr.Length / 19; f++)
        {
          GameInfo gameInfo = new GameInfo(StringToInt(arr[(19 * f)]), arr[(19 * f) + 1], StringToInt(arr[(19 * f) + 2]), StringToInt(arr[(19 * f) + 3]),
                                            arr[(19 * f) + 4], arr[(19 * f) + 5], arr[(19 * f) + 6], arr[(19 * f) + 7], arr[(19 * f) + 8], arr[(19 * f) + 9],
                                            arr[(19 * f) + 10], arr[(19 * f) + 11], arr[(19 * f) + 12], StringToInt(arr[(19 * f) + 13]), arr[(19 * f) + 14],
                                            arr[(19 * f) + 15], StringToInt(arr[(19 * f) + 16]), StringToInt(arr[(19 * f) + 17]), StringToInt(arr[(19 * f) + 18]));

          AddGameInfoToGame(gameInfo, list);

          Invoke(new Action(() =>
          {
            //label1.Text = "gameboy gameinfo fetched";
            progressBar1.Value++;
            label2.Text = progressBar1.Value + " / " + progressBar1.Maximum;
          }));

          //for(int b = 19*f + 19; arr[b] != "AchievementSectionEnd"; b++)
          //{

          //}
        }

        Invoke(new Action(() =>
        {
          //label1.Text = "gameboy gameinfo fetched";
          foreach (Game g in list)
          {
            comboBox1.Items.Add(g.Title);
          }
        }));
      }


    }

    private void AddGameInfoToGame(GameInfo info, List<Game> list)
    {
      list.Where<Game>(i => i.ID == info.ID).FirstOrDefault().GameInfo = info;
    }

    private void AddGameInfoToGame(GameInfo info, Game game)
    {
      game.GameInfo = info;
    }

    // returns a list which corresponds to the given consoleID
    private List<Game> GetGameListByConsoleID(int consoleID)
    {
      return _gameList[consoleID];
    }

    //Returns a parsed int, -1 if the string was empty
    private int StringToInt(string str)
    {
      if (str == "")
        return -1;
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
      Game g = _gameList[4].Where<Game>(i => i.Title == comboBox1.SelectedItem.ToString()).FirstOrDefault();
    }
  }
}