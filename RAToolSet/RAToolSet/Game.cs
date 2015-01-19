namespace RAToolSet
{
  /// <summary>
  /// Represents the basic information about a game.
  /// </summary>
  class Game
  {
    private string _title;
    private int _id;
    private int _consoleID;
    private string _consoleName;
    GameInfo _gameInfo;

    /// <summary>
    /// The title of this game.
    /// </summary>
    public string Title
    {
      get { return _title; }
      private set { _title = value; }
    }

    /// <summary>
    /// The id of this game.
    /// </summary>
    public int ID
    {
      get { return _id; }
      private set { _id = value; }
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
    /// The name of the console this game is on.
    /// </summary>
    public string ConsoleName
    {
      get { return _consoleName; }
      private set { _consoleName = value; }
    }

    /// <summary>
    /// The extended information of this game.
    /// </summary>
    public GameInfo GameInfo
    {
      get { return _gameInfo; }
      set { _gameInfo = value; }
    }

    public Game(string title, int id, int consoleID, string consoleName)
    {
      Title = title;
      ID = id;
      ConsoleID = consoleID;
      ConsoleName = consoleName;
    }
  }
}
