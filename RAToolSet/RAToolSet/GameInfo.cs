using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;

namespace RAToolSet
{
  /// <summary>
  /// Represents the extended information about a game.
  /// </summary>
  public class GameInfo
  {
    private int _id;
    private string _title;
    private int _consoleID;
    private int _forumTopicID;
    private string _flags;
    private string _imageIconString;
    private string _imageTitleString;
    private string _imageIngameString;
    private string _imageBoxArtString;
    private string _publisher;
    private string _developer;
    private string _genre;
    private string _released;
    private bool _isFinal;
    private string _consoleName;
    private string _richPresencePatch;
    private int _numAchievements;
    private int _numDistinctPlayersCasual;
    private int _numDistinctPlayersHardcore;

    private Image _imageIcon;
    private Image _imageTitle;
    private Image _imageIngame;
    private Image _imageBoxArt;
    private Dictionary<int, Achievement> _achievements = new Dictionary<int,Achievement>();

    /// <summary>
    /// The id of this game.
    /// </summary>
    public int ID
    {
      get { return _id; }
      private set { _id = value; }
    }

    /// <summary>
    /// The title of this game.
    /// </summary>
    public string Title
    {
      get { return _title; }
      private set { _title = value; }
    }

    /// <summary>
    /// The id of the console this game is on.
    /// </summary>
    public int ConsoleID
    {
      get { return _consoleID; }
      private set { _consoleID = value; }
    }

    /// <summary>
    /// The forum topic id of this game.
    /// </summary>
    public int ForumTopicID
    {
      get { return _forumTopicID; }
      private set { _forumTopicID = value; }
    }

    /// <summary>
    /// The flags of this game.
    /// </summary>
    public string Flags
    {
      get { return _flags; }
      private set { _flags = value; }
    }

    /// <summary>
    /// The url ending of the icon of this game.
    /// </summary>
    public string ImageIconString
    {
      get { return _imageIconString; }
      private set { _imageIconString = value; }
    }

    /// <summary>
    /// The url ending of the title screen of this game.
    /// </summary>
    public string ImageTitleString
    {
      get { return _imageTitleString; }
      private set { _imageTitleString = value; }
    }

    /// <summary>
    /// The url ending of the ingame image of this game.
    /// </summary>
    public string ImageIngameString
    {
      get { return _imageIngameString; }
      private set { _imageIngameString = value; }
    }

    /// <summary>
    /// The url ending of the box art of this game.
    /// </summary>
    public string ImageBoxArtString
    {
      get { return _imageBoxArtString; }
      private set { _imageBoxArtString = value; }
    }

    /// <summary>
    /// The publisher of this game.
    /// </summary>
    public string Publisher
    {
      get { return _publisher; }
      private set { _publisher = value; }
    }

    /// <summary>
    /// The developer of this game.
    /// </summary>
    public string Developer
    {
      get { return _developer; }
      private set { _developer = value; }
    }

    /// <summary>
    /// The genre of this game.
    /// </summary>
    public string Genre
    {
      get { return _genre; }
      private set { _genre = value; }
    }

    /// <summary>
    /// When this game was released (in irl, not RA).
    /// </summary>
    public string Released
    {
      get { return _released; }
      private set { _released = value; }
    }

    /// <summary>
    /// If this game has a full achievement set.
    /// </summary>
    public bool IsFinal
    {
      get { return _isFinal; }
      private set { _isFinal = value; }
    }

    /// <summary>
    /// The name of the console this game is on.
    /// </summary>
    public string ConsoleName
    {
      get { return _consoleName; }
      private set { _consoleName = value; }
    }

    /// <summary>
    /// The rich presence script of this game.
    /// </summary>
    public string RichPresencePatch
    {
      get { return _richPresencePatch; }
      private set { _richPresencePatch = value; }
    }

    /// <summary>
    /// The number of achievements this game has.
    /// </summary>
    public int NumAchievements
    {
      get { return _numAchievements; }
      private set { _numAchievements = value; }
    }

    /// <summary>
    /// The number of many distinct players played this game on casual mode.
    /// </summary>
    public int NumDistinctPlayersCasual
    {
      get { return _numDistinctPlayersCasual; }
      private set { _numDistinctPlayersCasual = value; }
    }

    /// <summary>
    /// The number of many distinct players played this game on hardcore mode.
    /// </summary>
    public int NumDistinctPlayersHardcore
    {
      get { return _numDistinctPlayersHardcore; }
      private set { _numDistinctPlayersHardcore = value; }
    }

    /// <summary>
    /// The achievements of this game.
    /// </summary>
    public Dictionary<int, Achievement> Achievements
    {
      get { return _achievements; }
      private set { _achievements = value; }
    }

    public Image ImageIcon
    {
      get { return _imageIcon; }
      private set { _imageIcon = value; }
    }

    public Image ImageTitle
    {
      get { return _imageTitle; }
      private set { _imageTitle = value; }
    }

    public Image ImageIngame
    {
      get { return _imageIngame; }
      private set { _imageIngame = value; }
    }

    public Image ImageBoxArt
    {
      get { return _imageBoxArt; }
      private set { _imageBoxArt = value; }
    }

    public GameInfo(int id, string title, int consoleID, int forumTopicID, string flags, string imageIcon, string imageTitle, string imageIngame, string imageBoxArt,
                    string publisher, string developer, string genre, string released, bool isFinal, string consoleName, string richPresencePatch,
                    int numAchievements, int numDistinctPlayersCasual, int numDistinctPlayersHardcore)
    {
      ID = id;
      Title = title;
      ConsoleID = consoleID;
      ForumTopicID = forumTopicID;
      Flags = flags;
      ImageIconString = imageIcon;
      ImageTitleString = imageTitle;
      ImageIngameString = imageIngame;
      ImageBoxArtString = imageBoxArt;
      Publisher = publisher;
      Developer = developer;
      Genre = genre;
      Released = released;
      IsFinal = isFinal;
      ConsoleName = consoleName;
      RichPresencePatch = richPresencePatch;
      NumAchievements = numAchievements;
      NumDistinctPlayersCasual = numDistinctPlayersCasual;
      NumDistinctPlayersHardcore = numDistinctPlayersHardcore;
    }

    public void FetchImages()
    {
      if (ImageIcon == null) //already fetched?
      {
        ImageIcon = GetImage(ImageIconString);
        ImageTitle = GetImage(ImageTitleString);
        ImageIngame = GetImage(ImageIngameString);
        ImageBoxArt = GetImage(ImageBoxArtString);
      }
    }

    /// <summary>
    /// Downloads the image from the RA website with the given parameter.
    /// </summary>
    /// <param name="urlEnding">The image to be downloaded.</param>
    /// <returns>Downloaded image.</returns>
    private Image GetImage(string urlEnding)
    {
      HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create("http://i.retroachievements.org" + urlEnding);
      httpWebRequest.Proxy = new WebProxy();
      HttpWebResponse httpWebReponse = (HttpWebResponse)httpWebRequest.GetResponse();
      Stream stream = httpWebReponse.GetResponseStream();
      return Image.FromStream(stream);
    }
  }
}
