using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;

namespace RAToolSet
{
  class GameInfo
  {
    private int _id;
    private string _title;
    private int _consoleID;
    private int _forumTopicID;
    private string _flags; //??
    private string _imageIconString;
    private string _imageTitleString;
    private string _imageIngameString;
    private string _imageBoxArtString;
    private string _publisher;
    private string _developer;
    private string _genre;
    private string _released;
    private int _isFinal;
    private string _consoleName;
    private string _richPresencePatch;
    private int _numAchievements;
    private int _numDistinctPlayersCasual;
    private int _numDistinctPlayersHardcore;

    private Image _imageIcon;
    private Image _imageTitle;
    private Image _imageIngame;
    private Image _imageBoxArt;
    private List<Achievement> _achievements;

    public int ID
    {
      get { return _id; }
      private set { _id = value; }
    }

    public string Title
    {
      get { return _title; }
      private set { _title = value; }
    }

    public int ConsoleID
    {
      get { return _consoleID; }
      private set { _consoleID = value; }
    }

    public int ForumTopicID
    {
      get { return _forumTopicID; }
      private set { _forumTopicID = value; }
    }

    public string Flags
    {
      get { return _flags; }
      private set { _flags = value; }
    }

    public string ImageIconString
    {
      get { return _imageIconString; }
      private set { _imageIconString = value; }
    }

    public string ImageTitleString
    {
      get { return _imageTitleString; }
      private set { _imageTitleString = value; }
    }

    public string ImageIngameString
    {
      get { return _imageIngameString; }
      private set { _imageIngameString = value; }
    }

    public string ImageBoxArtString
    {
      get { return _imageBoxArtString; }
      private set { _imageBoxArtString = value; }
    }

    public string Publisher
    {
      get { return _publisher; }
      private set { _publisher = value; }
    }

    public string Developer
    {
      get { return _developer; }
      private set { _developer = value; }
    }

    public string Genre
    {
      get { return _genre; }
      private set { _genre = value; }
    }

    public string Released
    {
      get { return _released; }
      private set { _released = value; }
    }

    public int IsFinal
    {
      get { return _isFinal; }
      private set { _isFinal = value; }
    }

    public string ConsoleName
    {
      get { return _consoleName; }
      private set { _consoleName = value; }
    }

    public string RichPresencePatch
    {
      get { return _richPresencePatch; }
      private set { _richPresencePatch = value; }
    }

    public int NumAchievements
    {
      get { return _numAchievements; }
      private set { _numAchievements = value; }
    }

    public int NumDistinctPlayersCasual
    {
      get { return _numDistinctPlayersCasual; }
      private set { _numDistinctPlayersCasual = value; }
    }

    public int NumDistinctPlayersHardcore
    {
      get { return _numDistinctPlayersHardcore; }
      private set { _numDistinctPlayersHardcore = value; }
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
                    string publisher, string developer, string genre, string released, int isFinal, string consoleName, string richPresencePatch,
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

      ImageIcon = GetImage(ImageIconString);
      ImageTitle = GetImage(ImageTitleString);
      ImageIngame = GetImage(ImageIngameString);
      ImageBoxArt = GetImage(ImageBoxArtString);
    }



    private Image GetImage(string urlEnding)
    {
      HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create("http://i.retroachievements.org" + urlEnding);
      HttpWebResponse httpWebReponse = (HttpWebResponse)httpWebRequest.GetResponse();
      Stream stream = httpWebReponse.GetResponseStream();
      return Image.FromStream(stream);
    }
  }
}
