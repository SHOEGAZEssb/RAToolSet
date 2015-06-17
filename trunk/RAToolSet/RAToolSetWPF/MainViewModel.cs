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

  /// <summary>
  /// The view model for the main view.
  /// </summary>
  class MainViewModel : PropertyChangedBase
  {
    #region Member

    private ObservableCollection<Console> _consoleList;
    private string _statusText;
    private Console _selectedConsole;
    private Game _selectedGame;

    /// <summary>
    /// Stopwatch used for measuring functions.
    /// </summary>
    private Stopwatch _watch;

    /// <summary>
    /// Backgroundworker that fetches console data.
    /// </summary>
    private BackgroundWorker _getConsolesWorker;

    /// <summary>
    /// Backgroundworker that fetches game lists.
    /// </summary>
    private BackgroundWorker _getGameListWorker;

    /// <summary>
    /// BackgroundWorker that fetches game info.
    /// </summary>
    private BackgroundWorker _getGameInfoWorker;

    /// <summary>
    /// The dispatcher of this thread. Used for invoking certain UI-thread calls.
    /// </summary>
    private Dispatcher _dispatcher;

    #endregion

    #region Properties

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

    /// <summary>
    /// The currently selected console in the view.
    /// </summary>
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

    /// <summary>
    /// The currently selected game in the view.
    /// </summary>
    public Game SelectedGame
    {
      get { return _selectedGame; }
      set
      {
        _selectedGame = value;
        if (value != null && !value.IsFetched)
          _getGameInfoWorker.RunWorkerAsync();

        NotifyOfPropertyChange(() => SelectedGame);
      }
    }

    /// <summary>
    /// The current status.
    /// </summary>
    public string StatusText
    {
      get { return _statusText; }
      private set
      {
        _statusText = value;
        Logging.LogText(value);
        NotifyOfPropertyChange(() => StatusText);
      }
    }

    public bool GameComboBoxEnabled
    {
      get { return (SelectedConsole != null && SelectedConsole.Games.Count != 0); }
    }

    #endregion

    /// <summary>
    /// Ctor.
    /// </summary>
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
      _getGameInfoWorker = new BackgroundWorker();
      _getGameInfoWorker.DoWork += new DoWorkEventHandler(getGameInfoWorker_DoWork);
    }

    /// <summary>
    /// Gets the data via a web request with the specified APIFunction and argument.
    /// </summary>
    /// <param name="apiFunction">APIFunction to call.</param>
    /// <param name="argument">Argument to pass.</param>
    /// <returns>Response from the WebRequest.</returns>
    private string GetWebRequestResponse(APIFunction apiFunction, string argument)
    {
      ServicePointManager.DefaultConnectionLimit = 20;
      ServicePointManager.Expect100Continue = false;
      ServicePointManager.UseNagleAlgorithm = false;

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

    #region BackgroundWorker DoWork Methods

    /// <summary>
    /// Worker to fetch all consoles
    /// </summary>
    private void getConsolesWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
    {
      StatusText = "Getting console data.";

      _watch.Reset();
      _watch.Start();
      string[] consoles = GetWebRequestResponse(APIFunction.GetConsoleIDs, "").Split(';');
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
    private void getGameListWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
    {
      StatusText = "Getting " + SelectedConsole.Name + " Game List.";

      _watch.Reset();
      _watch.Start();
      string json = GetWebRequestResponse(APIFunction.GetGameList, SelectedConsole.ID.ToString());
      _watch.Stop();

      StatusText = "Fetched " + SelectedConsole.Name + " Game List, took " + _watch.ElapsedMilliseconds + " milliseconds.";

      string[] games = json.Split(';');
      foreach (string game in games)
      {
        try
        {
          Game g = (JsonConvert.DeserializeObject<Game>(game));
          if(g != null)
            _dispatcher.Invoke(new System.Action(() => { SelectedConsole.Games.Add(g); }));
        }
        catch
        {
          //something went wrong with parsing, check game title for ';'
          continue;
        }
      }

      NotifyOfPropertyChange(() => GameComboBoxEnabled);
    }

    /// <summary>
    /// Gets the game info for all given game IDs
    /// </summary>
    /// <param name="e">Game ID to get info for</param>
    private void getGameInfoWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
    {
      //int gameID = (int)e.Argument;

      StatusText = "Getting " + SelectedGame.Title + " Game Info";

      _watch.Reset();
      _watch.Start();
      string info = GetWebRequestResponse(APIFunction.GetGameExtended, SelectedGame.ID.ToString());
      _watch.Stop();

      StatusText = "Fetched " + SelectedGame.Title + " Game Info, took " + _watch.ElapsedMilliseconds + " milliseconds.";

      // TODO: write a "merge" function to add the serialized properties to the original game
      Game g = JsonConvert.DeserializeObject<Game>(info);


      for(int i = 0; i < SelectedConsole.Games.Count; i++)
      {
        if (SelectedConsole.Games[i].ID == g.ID)
        {
          _dispatcher.Invoke(new System.Action(() => 
          {
            SelectedConsole.Games[i].MergeGame(g);       
          }));
          break;
        }
      }

      NotifyOfPropertyChange(() => SelectedGame);

      //Remove old game with less info and add the new one.
      //GetConsoleByID(g.ConsoleID).Games.Remove((Game)GetConsoleByID(g.ConsoleID).Games.Where(i => i.ID == g.ID).FirstOrDefault());
      //GetConsoleByID(g.ConsoleID).Games.Add(g);
      //_fullyFetchedGames.Add(g.ID);

      //if (g.Achievements != null) // for some reason now the dictionary does not get inizialized when no cheevos exist.
      //{
      //  Invoke(new Action(() =>
      //  {
      //    comboBoxAchievement.Items.Clear();
      //    foreach (Achievement a in g.Achievements.Values)
      //    {
      //      comboBoxAchievement.Items.Add(a.Title);
      //    }
      //  }));
      //}
      //else
      //  g.Achievements = new Dictionary<int, Achievement>();
    }

    #endregion
  }
}
