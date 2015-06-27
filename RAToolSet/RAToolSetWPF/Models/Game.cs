using Caliburn.Micro;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Runtime.Serialization;

namespace RAToolSetWPF
{
  /// <summary>
  /// Represents the extended information about a game.
  /// </summary>
  [DataContract]
  public class Game : PropertyChangedBase
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

    private bool _isFetched;

    private ImageSource _imageIcon;
    private ImageSource _imageTitle;
    private ImageSource _imageIngame;
    private ImageSource _imageBoxArt;
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
    [DataMember(Name="Achievements")]
    public Dictionary<int, Achievement> Achievements
    {
      get { return _achievements; }
      set 
      { 
        _achievements = value;
        NotifyOfPropertyChange(() => Achievements);
      } //TODO: safety
    }

    /// <summary>
    /// Gets/sets wether the whole game info for this game has been fetched.
    /// </summary>
    public bool IsFetched
    {
      get { return _isFetched; }
      private set { _isFetched = value; }
    }

    /// <summary>
    /// The icon of this game.
    /// </summary>
    public ImageSource ImageIcon
    {
      get { return _imageIcon; }
      private set { _imageIcon = value; }
    }

    /// <summary>
    /// The titlescreen of this game.
    /// </summary>
    public ImageSource ImageTitle
    {
      get { return _imageTitle; }
      private set { _imageTitle = value; }
    }

    /// <summary>
    /// The gameplay screenshot of this game.
    /// </summary>
    public ImageSource ImageIngame
    {
      get { return _imageIngame; }
      private set { _imageIngame = value; }
    }

    /// <summary>
    /// The boxart of this game.
    /// </summary>
    public ImageSource ImageBoxArt
    {
      get { return _imageBoxArt; }
      private set { _imageBoxArt = value; }
    }

    /// <summary>
    /// Ctor.
    /// </summary>
    public Game(int id, string title, int consoleID, int forumTopicID, string flags, string imageIcon, string imageTitle, string imageIngame, string imageBoxArt,
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

    /// <summary>
    /// Downloads all images of this game.
    /// </summary>
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
    /// Downlaods only the icon image of this game.
    /// </summary>
    public void FetchIcon()
    {
      ImageIcon = GetImage(ImageIconString);
    }

    /// <summary>
    /// Downloads the image from the RA website with the given parameter.
    /// </summary>
    /// <param name="urlEnding">The image to be downloaded.</param>
    /// <returns>Downloaded image.</returns>
    private ImageSource GetImage(string urlEnding)
    {
      if (urlEnding != null)
      {
        BitmapImage imageSource = new BitmapImage();
        imageSource.BeginInit();
        imageSource.UriSource = new System.Uri("http://i.retroachievements.org" + urlEnding);
        imageSource.EndInit();
        return imageSource;
      }

      return null;
    }

    /// <summary>
    /// Merges a fetched game with this game.
    /// </summary>
    /// <param name="g">Game to merge.</param>
    public void MergeGame(Game g)
    {
      Developer = g.Developer;
      Publisher = g.Publisher;
      Genre = g.Genre;
      Released = g.Released;
      IsFinal = g.IsFinal;
      RichPresencePatch = g.RichPresencePatch;
      NumAchievements = g.NumAchievements;
      NumDistinctPlayersCasual = g.NumDistinctPlayersCasual;
      NumDistinctPlayersHardcore = g.NumDistinctPlayersHardcore;
      Flags = g.Flags;
      ImageBoxArtString = g.ImageBoxArtString;
      ImageTitleString = g.ImageTitleString;
      ImageIngameString = g.ImageIngameString;
      ForumTopicID = g.ForumTopicID;
      Achievements = g.Achievements;

      FetchIcon();
      IsFetched = true;
    }
  }
}