using Caliburn.Micro;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

namespace RAToolSetWPF
{
  /// <summary>
  /// Represents the ViewModel for the user inspector.
  /// </summary>
  class UserViewModel : PropertyChangedBase
  {
    /// <summary>
    /// A reference to the MainViewModel.
    /// </summary>
    private MainViewModel _mainViewModel;

    /// <summary>
    /// Stopwatch used for measuring functions.
    /// </summary>
    private Stopwatch _watch;

    private string _enteredUsername;
    private User _selectedUser;
    private List<User> _fetchedUsers;
    private BackgroundWorker _getUserWorker;

    /// <summary>
    /// The username entered in the textBox.
    /// </summary>
    public string EnteredUsername
    {
      get { return _enteredUsername; }
      set { _enteredUsername = value; }
    }

    /// <summary>
    /// The currently displayed user.
    /// </summary>
    public User SelectedUser
    {
      get { return _selectedUser; }
      private set
      {
        _selectedUser = value;
        NotifyOfPropertyChange(() => SelectedUser);
        NotifyOfPropertyChange(() => UserSeperatorVisible);
      }
    }

    public bool UserSeperatorVisible
    {
      get { return SelectedUser != null; }
    }

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="mainViewModel">Reference to the parent MainViewModel.</param>
    public UserViewModel(MainViewModel mainViewModel)
    {
      _mainViewModel = mainViewModel;
      _watch = new Stopwatch();
      _fetchedUsers = new List<User>();
      _getUserWorker = new BackgroundWorker();
      _getUserWorker.DoWork += new DoWorkEventHandler(getUserWorker_DoWork);
    }

    /// <summary>
    /// Checks if the user was already fetched, otherwise fetches it.
    /// </summary>
    public void LoadInfo()
    {
      User usr = _fetchedUsers.FirstOrDefault(i => i.Username == EnteredUsername);
      if (usr == null)
        _getUserWorker.RunWorkerAsync();
      else
        SelectedUser = usr;
    }

    /// <summary>
    /// Gets the user info for the given <see cref="EnteredUsername"/>
    /// </summary>
    private void getUserWorker_DoWork(object sender, DoWorkEventArgs e)
    {
      _mainViewModel.StatusText = "Getting " + EnteredUsername + " user info.";

      _watch.Start();
      string text = MainViewModel.GetWebRequestResponse(APIFunction.GetUserSummary, EnteredUsername).Replace(';', ','); // hacky.
      if (text.Substring(15, 4) != null) // user does not exist.
      {
        MainViewModel.Dispatcher.Invoke(new System.Action(() =>
          {
            User usr = JsonConvert.DeserializeObject<User>(text);
            _fetchedUsers.Add(usr);
            SelectedUser = usr;
          }));
      }
      _watch.Stop();

      _mainViewModel.StatusText = "Fetched " + EnteredUsername + " user info, took " + _watch.ElapsedMilliseconds + " ms.";
      _watch.Reset();
    }
  }
}