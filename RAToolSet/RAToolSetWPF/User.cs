using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace RAToolSetWPF
{
  /// <summary>
  /// Represents the user summary of a RetroAchievements user.
  /// </summary>
  class User
  {
    private string _username;
    private string _memberSince;
    private string _lastLogin;
    private int _contribCount;
    private int _contribYield;
    private int _totalPoints;
    private int _totalTruePoints;
    private int _permissions;
    private string _motto;
    private int _rank;
    private string _userPic;
    private ImageSource _userPicture;

    /// <summary>
    /// The username of this user.
    /// </summary>
    public string Username
    {
      get { return _username; }
      private set { _username = value; }
    }

    /// <summary>
    /// Since when this user is registered on RetroAchievements.
    /// </summary>
    public string MemberSince
    {
      get { return _memberSince; }
      private set { _memberSince = value; }
    }

    /// <summary>
    /// When this user logged in last on RetroAchievements
    /// </summary>
    public string LastLogin
    {
      get { return _lastLogin; }
      private set { _lastLogin = value; }
    }

    /// <summary>
    /// How many times the achievements created by this user were earned.
    /// </summary>
    public int ContribCount
    {
      get { return _contribCount; }
      private set { _contribCount = value; }
    }

    /// <summary>
    /// How many points the achievements created by this user gave to other users.
    /// </summary>
    public int ContribYield
    {
      get { return _contribYield; }
      private set { _contribYield = value; }
    }

    /// <summary>
    /// The amount of points this user has earned.
    /// </summary>
    public int TotalPoints
    {
      get { return _totalPoints; }
      private set { _totalPoints = value; }
    }

    /// <summary>
    /// The amount of true points this user has earned.
    /// </summary>
    public int TotalTruePoints
    {
      get { return _totalTruePoints; }
      private set { _totalTruePoints = value; }
    }

    /// <summary>
    /// The permissions ID of this user.
    /// </summary>
    public int Permissions
    {
      get { return _permissions; }
      private set { _permissions = value; }
    }

    /// <summary>
    /// The motto of this user.
    /// </summary>
    public string Motto
    {
      get { return _motto; }
      private set { _motto = value; }
    }

    /// <summary>
    /// The site rank of this user.
    /// </summary>
    public int Rank
    {
      get { return _rank; }
      private set { _rank = value; }
    }

    /// <summary>
    /// The picture string of this user.
    /// </summary>
    public string UserPic
    {
      get { return _userPic; }
      private set 
      { 
        _userPic = value;
        Username = UserPic.Replace("/UserPic/", "");
      }
    }

    /// <summary>
    /// The picture of this user.
    /// </summary>
    public ImageSource UserPicture
    {
      get { return _userPicture; }
      private set { _userPicture = value; }
    }

    /// <summary>
    /// Ctor.
    /// </summary>
    public User(string memberSince, string lastLogin, int contribCount, int contribYield, int totalPoints, int totalTruePoints, int permissions, string motto, int rank, string userPic)
    {
      MemberSince = memberSince;
      LastLogin = lastLogin;
      ContribCount = contribCount;
      ContribYield = contribYield;
      TotalPoints = totalPoints;
      TotalTruePoints = totalTruePoints;
      Permissions = permissions;
      Motto = motto;
      Rank = rank;
      UserPic = userPic;
      UserPicture = FetchIcon();
    }

    /// <summary>
    /// Downloads the user picture.
    /// </summary>
    /// <returns>Downloaded user picture.</returns>
    private ImageSource FetchIcon()
    {
      BitmapImage imageSource = new BitmapImage();
      imageSource.BeginInit();
      imageSource.UriSource = new System.Uri("http://retroachievements.org" + UserPic);
      imageSource.EndInit();
      return imageSource;
    }
  }
}