using System.Collections.Generic;

namespace RAToolSet
{
  class GameInfo
  {
    int _id;
    string _title;
    int _consoleID;
    int _forumTopicID;   
    string _flags; //??
    string _imageIcon;
    string _imageTitle;
    string _imageIngame;
    string _imageBoxArt;
    string _publisher;
    string _developer;
    string _genre;
    string _released;
    int _isFinal;
    string _consoleName;
    string _richPresencePatch;
    int _numAchievements;
    int _numDistinctPlayersCasual;
    int _numDistinctPlayersHardcore;
    List<Achievement> _achievements;

    public int ID
    {
      get
      {
        return _id;
      }
    }

    public GameInfo(int id, string title, int consoleID, int forumTopicID, string flags, string imageIcon, string imageTitle, string imageIngame, string imageBoxArt,
                    string publisher, string developer, string genre, string released, int isFinal, string consoleName, string richPresencePatch,
                    int numAchievements, int numDistinctPlayersCasual, int numDistinctPlayersHardcore)
    {
      _id = id;
      _title = title;
      _consoleID = consoleID;
      _forumTopicID = forumTopicID;
      _flags = flags;
      _imageIcon = imageIcon;
      _imageTitle = imageTitle;
      _imageIngame = imageIngame;
      _imageBoxArt = imageBoxArt;
      _publisher = publisher;
      _developer = developer;
      _genre = genre;
      _released = released;
      _isFinal = isFinal;
      _consoleName = consoleName;
      _richPresencePatch = richPresencePatch;
      _numAchievements = numAchievements;
      _numDistinctPlayersCasual = numDistinctPlayersCasual;
      _numDistinctPlayersHardcore = numDistinctPlayersHardcore;

    }

    public GameInfo()
    {

    }

  }
}
