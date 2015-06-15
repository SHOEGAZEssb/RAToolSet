namespace RAToolSetWPF
{
  /// <summary>
  /// Represents a single achievement of a game.
  /// </summary>
  public class Achievement
  {
    int _id;
    int _numAwarded;
    int _numAwardedHardcore;
    string _title;
    string _description;
    int _points;
    int _trueRatio;
    string _author;
    string _dateModified;
    string _dateCreated;
    int _badgeID;
    int _displayOrder;
    string _memAddr;

    /// <summary>
    /// The id of this achievement.
    /// </summary>
    public int ID
    {
      get { return _id; }
      private set { _id = value; }
    }

    /// <summary>
    /// How often this achievement has been awarded.
    /// </summary>
    public int NumAwarded
    {
      get { return _numAwarded; }
      private set { _numAwarded = value; }
    }

    /// <summary>
    /// How often this achievement has been awarded on hardcore.
    /// </summary>
    public int NumAwardedHardcore
    {
      get { return _numAwardedHardcore; }
      private set { _numAwardedHardcore = value; }
    }

    /// <summary>
    /// The title of this achievement.
    /// </summary>
    public string Title
    {
      get { return _title; }
      private set { _title = value; }
    }

    /// <summary>
    /// The description of this achievement.
    /// </summary>
    public string Description
    {
      get { return _description; }
      private set { _description = value; }
    }

    /// <summary>
    /// The points this achievement is worth.
    /// </summary>
    public int Points
    {
      get { return _points; }
      private set { _points = value; }
    }

    /// <summary>
    /// The true ratio of this achievement.
    /// </summary>
    public int TrueRatio
    {
      get { return _trueRatio; }
      private set { _trueRatio = value; }
    }

    /// <summary>
    /// The name of the user who created this achievement.
    /// </summary>
    public string Author
    {
      get { return _author; }
      private set { _author = value; }
    }

    /// <summary>
    /// The date the achievement was modified last.
    /// </summary>
    public string DateModified
    {
      get { return _dateModified; }
      private set { _dateModified = value; }
    }

    /// <summary>
    /// The date the achievement was created.
    /// </summary>
    public string DateCreated
    {
      get { return _dateCreated; }
      private set { _dateCreated = value; }
    }

    /// <summary>
    /// The id of the badge of this achievement.
    /// </summary>
    public int BadgeID
    {
      get { return _badgeID; }
      private set { _badgeID = value; }
    }

    /// <summary>
    /// The display order of this achievement.
    /// </summary>
    public int DisplayOrder
    {
      get { return _displayOrder; }
      private set { _displayOrder = value; }
    }

    /// <summary>
    /// The memory addresses and their conditions for this achievement.
    /// </summary>
    public string MemAddr
    {
      get { return _memAddr; }
      private set { _memAddr = value; }
    }

    /// <summary>
    /// Ctor.
    /// </summary>
    public Achievement(int id, int numAwarded, int numAwardedHardcore, string title, string description, int points, int trueRatio, string author,
                       string dateModified, string dateCreated, int badgeID, int displayOrder, string memAddr)                       
    {
      ID = id;
      NumAwarded = numAwarded;
      NumAwardedHardcore = numAwardedHardcore;
      Title = title;
      Description = description;
      Points = points;
      TrueRatio = trueRatio;
      Author = author;
      DateModified = dateModified;
      DateCreated = dateCreated;
      BadgeID = badgeID;
      DisplayOrder = displayOrder;
      MemAddr = memAddr;
    }
  }
}