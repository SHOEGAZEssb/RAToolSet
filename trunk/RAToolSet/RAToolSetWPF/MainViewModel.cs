using Caliburn.Micro;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;


namespace RAToolSetWPF
{
  /// <summary>
  /// Enum which contains all available functions of the RA web api.
  /// </summary>
  public enum APIFunction
  {
    GetConsoleIDs,
    GetGameList,
    GetGameExtended,
    GetAchievementCount
  }

  class MainViewModel : PropertyChangedBase
  {
    private ObservableCollection<Console> _consoleList;
    private string _statusText;
    private Console _selectedConsole;
    private Game _selectedGame;

    private Stopwatch _watch;
    private BackgroundWorker _getConsolesWorker;
    private BackgroundWorker _getGameListWorker;
    private Dispatcher _dispatcher;

    /// <summary>
    /// List of fetched consoles.
    /// </summary>
    public ObservableCollection<Console> ConsoleList
    {
      get { return _consoleList; }
      private set 
      { 
        _consoleList = value;
      }
    }

    public Console SelectedConsole
    {
      get { return _selectedConsole; }
      set
      {
        _selectedConsole = value;
        NotifyOfPropertyChange(() => SelectedConsole);

        _getGameListWorker.RunWorkerAsync();
      }
    }

    public Game SelectedGame
    {
      get { return _selectedGame; }
      set
      {
        _selectedGame = value;
        NotifyOfPropertyChange(() => SelectedGame);
      }
    }

    public string StatusText
    {
      get { return _statusText; }
      private set
      {
        _statusText = value;
        NotifyOfPropertyChange(() => StatusText);
      }
    }


    public MainViewModel()
    {
      // Initialize variables
      ConsoleList = new ObservableCollection<Console>();
      _dispatcher = Dispatcher.CurrentDispatcher;
      _watch = new Stopwatch();
      _getConsolesWorker = new BackgroundWorker();
      _getConsolesWorker.DoWork += new DoWorkEventHandler(getConsolesWorker_DoWork);
      _getConsolesWorker.RunWorkerAsync();

      _getGameListWorker = new BackgroundWorker();
      _getGameListWorker.DoWork += new DoWorkEventHandler(getGameListWorker_DoWork);
    }

    /// <summary>
    /// Gets the data via a web request with the specified APIFunction and argument.
    /// </summary>
    /// <param name="apiFunction">APIFunction to call.</param>
    /// <param name="argument">Argument to pass.</param>
    /// <returns>Response from the WebRequest.</returns>
    private string GetWebRequestString(APIFunction apiFunction, string argument)
    {
      //var request = WebRequest.Create("http://retroachievements.org/API/API_" + apiFunction + ".php?z=" + RAToolSetWPF.Properties.Settings.Default.Username + "&y=" + RAToolSetWPF.Properties.Settings.Default.APIKey + "&i=" + argument);
      var request = WebRequest.Create("http://retroachievements.org/API/API_" + apiFunction + ".php?z=coczero" + "&y=AEwHP8tc6G9JaUweJl3zMZq2CRj2uIPV" + "&i=" + argument);
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
    /// Worker to fetch all consoles
    /// </summary>
    private void getConsolesWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
    {
      StatusText = "Getting console data.";

      _watch.Reset();
      _watch.Start();
      string[] consoles = GetWebRequestString(APIFunction.GetConsoleIDs, "").Split(';');
      _watch.Stop();



      StatusText = "Fetched Console Information, took " + _watch.ElapsedMilliseconds + " milliseconds.";

      Dispatcher.CurrentDispatcher.Invoke(() =>
      {
        foreach (string console in consoles)
        {
          Console c = JsonConvert.DeserializeObject<Console>(console);
          _dispatcher.Invoke(new System.Action(() => { ConsoleList.Add(c); }));
        }
      });
    }

    /// <summary>
    /// Gets the game list of the specified console ID.
    /// </summary>
    /// <param name="e">Console ID to get game list for.</param>
    private void getGameListWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
    {
      StatusText = "Getting " + SelectedConsole.Name + " Game List.";

      _watch.Reset();
      _watch.Start();
      string json = GetWebRequestString(APIFunction.GetGameList, SelectedConsole.ID.ToString());
      _watch.Stop();

      StatusText = "Fetched " + SelectedConsole.Name + " Game List, took " + _watch.ElapsedMilliseconds + " milliseconds.";

      string[] games = json.Split(';');
      foreach (string game in games)
      {
        try
        {
          _dispatcher.Invoke(new System.Action(() => { SelectedConsole.Games.Add((JsonConvert.DeserializeObject<Game>(game))); }));
        }
        catch
        {
          //something went wrong with parsing, check game title for ';'
          continue;
        }
      }

      //comboBoxGame.Enabled = true;

      //SelectedGame = null;
    }
  }
}
