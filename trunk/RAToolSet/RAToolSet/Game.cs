using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RAToolSet
{
  class Game
  {
    private string _title;
    private int _id;
    private int _consoleID;
    private string _consoleName;
    GameInfo _gameInfo;

    public string Title
    {
      get
      {
        return _title;
      }
    }

    public int ID
    {
      get
      {
        return _id;
      }
    }

    public GameInfo GameInfo
    {
      get
      {
        return _gameInfo;
      }

      set
      {
        _gameInfo = value;
      }
    }

    public Game(string title, int id, int consoleID, string consoleName)
    {
      _title = title;
      _id = id;
      _consoleID = consoleID;
      _consoleName = consoleName;
    }

    
  }
}
