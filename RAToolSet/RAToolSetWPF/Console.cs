using System.Collections.ObjectModel;

namespace RAToolSetWPF
{
  /// <summary>
  /// Represents a console with games.
  /// </summary>
  class Console
  {
    private int _id;
    private string _name;
    private ObservableCollection<Game> _games;

    /// <summary>
    /// The id of this console.
    /// </summary>
    public int ID
    {
      get { return _id; }
      private set { _id = value; }
    }

    /// <summary>
    /// The name of this console.
    /// </summary>
    public string Name
    {
      get { return _name; }
      private set { _name = value; }
    }

    /// <summary>
    /// All games on this console.
    /// </summary>
    public ObservableCollection<Game> Games
    {
      get { return _games; }
      private set 
      { 
        _games = value;
      }
    }

    /// <summary>
    /// Ctor.
    /// </summary>
    public Console(int id, string name)
    {
      ID = id;
      Name = name;
      Games = new ObservableCollection<Game>();
    }
  }
}