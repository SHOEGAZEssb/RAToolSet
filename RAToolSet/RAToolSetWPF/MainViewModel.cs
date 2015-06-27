using Caliburn.Micro;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows;
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
    GetAchievementCount,
    GetUserSummary
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
    private Achievement _selectedAchievement;

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

    private static Dispatcher _dispatcher;

    private ConditionViewModel _conditionViewModel;
    private UserViewModel _userViewModel;

    #endregion

    #region Properties

    /// <summary>
    /// List of fetched consoles.
    /// </summary>
    public ObservableCollection<Console> ConsoleList
    {
      get { return _consoleList; }
      private set { _consoleList = value; }
    }

    /// <summary>
    /// The currently selected console in the view.
    /// </summary>
    public Console SelectedConsole
    {
      get { return _selectedConsole; }
      set
      {
        if (!_getGameListWorker.IsBusy)
        {
          _selectedConsole = value;

          if (value != null && !value.IsFetched)
            _getGameListWorker.RunWorkerAsync();

          NotifyOfPropertyChange(() => SelectedConsole);
        }
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
        if (!_getGameInfoWorker.IsBusy)
        {
          _selectedGame = value;
          if (value != null && !value.IsFetched)
            _getGameInfoWorker.RunWorkerAsync();

          NotifyOfPropertyChange(() => SelectedGame);
          NotifyOfPropertyChange(() => AchievementComboBoxEnabled);
          NotifyOfPropertyChange(() => GameSeperatorVisible);
          NotifyOfPropertyChange(() => AchievementPointSum);
        }
      }
    }

    /// <summary>
    /// The currently selected achievement in the view.
    /// </summary>
    public Achievement SelectedAchievement
    {
      get { return _selectedAchievement; }
      set
      {
        _selectedAchievement = value;
        if (SelectedAchievement != null && SelectedAchievement.Badge == null)
          SelectedAchievement.FetchBadge();

        NotifyOfPropertyChange(() => SelectedAchievement);
        NotifyOfPropertyChange(() => AchievementSeperatorVisible);       
      }
    }

    /// <summary>
    /// The current status.
    /// </summary>
    public string StatusText
    {
      get { return _statusText; }
      set
      {
        _statusText = value;
        Logging.LogText(value);
        NotifyOfPropertyChange(() => StatusText);
      }
    }

    /// <summary>
    /// The dispatcher of this thread. Used for invoking certain UI-thread calls.
    /// </summary>
    public static Dispatcher Dispatcher
    {
      get { return _dispatcher; }
      private set { _dispatcher = value; }
    }

    public ConditionViewModel ConditionViewModel
    {
      get { return _conditionViewModel; }
      private set { _conditionViewModel = value; }
    }

    public UserViewModel UserViewModel
    {
      get { return _userViewModel; }
      private set { _userViewModel = value; }
    }

    #region Enable and Visibility Properties

    /// <summary>
    /// Gets wether the game combobox on the view is enabled.
    /// </summary>
    public bool GameComboBoxEnabled
    {
      get { return (SelectedConsole != null && SelectedConsole.Games.Count != 0); }
    }

    public bool GameSeperatorVisible
    {
      get { return SelectedGame != null; }
    }

    /// <summary>
    /// Gets wether the achievement combobox on the view is enabled.
    /// </summary>
    public bool AchievementComboBoxEnabled
    {
      get { return (SelectedGame != null && SelectedGame.Achievements != null && SelectedGame.Achievements.Count != 0); }
    }

    /// <summary>
    /// Gets wether the achievement seperators are visible on the view.
    /// </summary>
    public bool AchievementSeperatorVisible
    {
      get { return SelectedAchievement != null; }
    }

    #endregion

    /// <summary>
    /// Gets the sum of all points of the achievements of the selected game.
    /// </summary>
    public int AchievementPointSum
    {
      get
      {
        int sum = 0;
        if(SelectedGame != null && SelectedGame.Achievements != null)
        {
          foreach(Achievement ach in SelectedGame.Achievements.Values)
          {
            sum += ach.Points;
          }
        }

        return sum;
      }
    }

    #endregion

    /// <summary>
    /// Ctor.
    /// </summary>
    public MainViewModel()
    {
      // Initialize variables
      ConditionViewModel = new RAToolSetWPF.ConditionViewModel();
      UserViewModel = new UserViewModel(this);
      ConsoleList = new ObservableCollection<Console>();
      Dispatcher = Dispatcher.CurrentDispatcher;
      _watch = new Stopwatch();
      _getConsolesWorker = new BackgroundWorker();
      _getConsolesWorker.DoWork += new DoWorkEventHandler(getConsolesWorker_DoWork);
      _getGameListWorker = new BackgroundWorker();
      _getGameListWorker.DoWork += new DoWorkEventHandler(getGameListWorker_DoWork);
      _getGameInfoWorker = new BackgroundWorker();
      _getGameInfoWorker.DoWork += new DoWorkEventHandler(getGameInfoWorker_DoWork);
    }

    /// <summary>
    /// Tries to log in the user before fetching any data.
    /// </summary>
    public void WindowLoaded()
    {
      bool? dialogResult = true;

      if (RAToolSetWPF.Properties.Settings.Default.Username == "" || RAToolSetWPF.Properties.Settings.Default.APIKey == "")
      {
        LoginWindow lw = new LoginWindow();
        dialogResult = lw.ShowDialog();
      }

      if (dialogResult.Value)
        _getConsolesWorker.RunWorkerAsync();
      else
        Application.Current.Shutdown();
    }

    /// <summary>
    /// Gets the data via a web request with the specified APIFunction and argument.
    /// </summary>
    /// <param name="apiFunction">APIFunction to call.</param>
    /// <param name="argument">Argument to pass.</param>
    /// <returns>Response from the WebRequest.</returns>
    public static string GetWebRequestResponse(APIFunction apiFunction, string argument)
    {
      ServicePointManager.DefaultConnectionLimit = 20;
      ServicePointManager.Expect100Continue = false;
      ServicePointManager.UseNagleAlgorithm = false;

      WebRequest request;

      if (apiFunction != APIFunction.GetUserSummary)
      {
        request = WebRequest.Create("http://retroachievements.org/API/API_" + apiFunction + ".php?z=" + RAToolSetWPF.Properties.Settings.Default.Username +
          "&y=" + RAToolSetWPF.Properties.Settings.Default.APIKey + "&i=" + argument);
      }
      else
      {
        // needed to use argument 'u' and 'g'
        request = WebRequest.Create("http://retroachievements.org/API/API_" + apiFunction + ".php?z=" + RAToolSetWPF.Properties.Settings.Default.Username +
          "&y=" + RAToolSetWPF.Properties.Settings.Default.APIKey + "&u=" + argument + "&g=0");
      }

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
    /// Opens the forum topic of the selected game in the standard browser.
    /// </summary>
    public void ForumTopicClicked()
    {
      string link = "http://retroachievements.org/viewtopic.php?t=&c=".Replace("t=", "t=" + SelectedGame.ForumTopicID);
      Process.Start(link);
    }

    /// <summary>
    /// Opens the user page of the author of the selected achievement.
    /// </summary>
    public void AuthorClicked()
    {
      string link = "http://retroachievements.org/User/" + SelectedAchievement.Author;
      Process.Start(link);
    }

    /// <summary>
    /// Shows a window with the rich presence script of the selected game.
    /// </summary>
    public void RichPresenceClicked()
    {
      RichPresenceWindow rpw = new RichPresenceWindow(SelectedGame.RichPresencePatch);
      rpw.Show();
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
          if (g != null)
            _dispatcher.Invoke(new System.Action(() => { SelectedConsole.Games.Add(g); }));
        }
        catch
        {
          //something went wrong with parsing, check game title for ';'
          continue;
        }
      }

      SelectedConsole.IsFetched = true;
      NotifyOfPropertyChange(() => GameComboBoxEnabled);
    }

    /// <summary>
    /// Gets the game info for all given game IDs
    /// </summary>
    /// <param name="e">Game ID to get info for</param>
    private void getGameInfoWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
    {
      StatusText = "Getting " + SelectedGame.Title + " Game Info";

      _watch.Reset();
      _watch.Start();
      string info = GetWebRequestResponse(APIFunction.GetGameExtended, SelectedGame.ID.ToString());
      _watch.Stop();

      StatusText = "Fetched " + SelectedGame.Title + " Game Info, took " + _watch.ElapsedMilliseconds + " milliseconds.";

      Game g = JsonConvert.DeserializeObject<Game>(info);

      for (int i = 0; i < SelectedConsole.Games.Count; i++)
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
      NotifyOfPropertyChange(() => AchievementComboBoxEnabled);
      NotifyOfPropertyChange(() => AchievementPointSum);
    }

    #endregion
  }
}