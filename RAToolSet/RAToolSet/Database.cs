using System.Data.SQLite;
using System.Diagnostics;

namespace RAToolSet
{
  /// <summary>
  /// Represents the database with the game and achievement infos.
  /// </summary>
  class Database
  {
    private SQLiteConnection _connection;

    /// <summary>
    /// The connection to the database.
    /// </summary>
    public SQLiteConnection Connection
    {
      get { return _connection; }
      private set { _connection = value; }
    }

    /// <summary>
    /// Ctor.
    /// Loads the database and creates tables for games and achievements if they not exist.
    /// </summary>
    public Database()
    {
      Connection = new SQLiteConnection();
      Connection.ConnectionString = @"Data Source=..\..\database.db";
      Connection.Open();

      //Add tables if they dont exist
      SQLiteCommand cmd = new SQLiteCommand(Connection);
      cmd.CommandText = "CREATE TABLE IF NOT EXISTS Games ( ID INTEGER PRIMARY KEY ASC, Title TEXT, ConsoleID INTEGER, Flags TEXT, ImageIconString TEXT, " +
                        "ImageTitleString TEXT, ImageIngameString TEXT, ImageBoxArtString TEXT, Publisher TEXT, Developer TEXT, Genre TEXT, Released TEXT, " +
                        "IsFinal BOOLEAN, ConsoleName TEXT, RichPresencePatch TEXT, NumAchievements INTEGER, NumDistinctPlayersCasual INTEGER, NumDistinctPlayersHardcore INTEGER);";
      cmd.ExecuteNonQuery();

      cmd.CommandText = "CREATE TABLE IF NOT EXISTS Achievements ( ID INTEGER PRIMARY KEY, NumAwarded INTEGER, NumAwardedHardcore INTEGER, Title TEXT, GameID INTEGER, " +
                        "Description TEXT, Points INTEGER, TrueRatio INTEGER, Author TEXT, DateModified TEXT, DateCreated TEXT, BadgeID INTEGER, DisplayOrder INTEGER, MemAddr TEXT);";
      cmd.ExecuteNonQuery();
      cmd.Dispose();
    }

    /// <summary>
    /// Insert a game and its achievements in the database.
    /// </summary>
    /// <param name="g">Game to insert into the database.</param>
    public void InsertGame(Game g)
    {
      Stopwatch watch = new Stopwatch();
      watch.Start();

      SQLiteCommand cmd = new SQLiteCommand(Connection);

      string title = EscapeSpecialCharacters(g.Title);
      string genre = EscapeSpecialCharacters(g.Genre);
      string publisher = EscapeSpecialCharacters(g.Publisher);
      string developer = EscapeSpecialCharacters(g.Developer);
      string richPresencePatch = EscapeSpecialCharacters(g.RichPresencePatch);

      cmd.CommandText = "INSERT OR REPLACE INTO Games(ID, Title, ConsoleID, Flags, ImageIconString, ImageTitleString, ImageIngameString, ImageBoxArtString, " +
                        "Publisher, Developer, Genre, Released, IsFinal, ConsoleName, RichPresencePatch, NumAchievements, NumDistinctPlayersCasual, " +
                        "NumDistinctPlayersHardcore) " +
                        "VALUES('" + g.ID + "'," + "'" + title + "'," + "'" + g.ConsoleID + "'," + "'" + g.Flags + "'," + "'" + g.ImageIconString + "'," +
                        "'" + g.ImageTitleString + "'," + "'" + g.ImageIngameString + "'," + "'" + g.ImageBoxArtString + "'," + "'" + publisher + "'," +
                        "'" + developer + "'," + "'" + genre + "'," + "'" + g.Released + "'," + "'" + g.IsFinal + "'," + "'" + g.ConsoleName + "'," +
                        "'" + richPresencePatch + "'," + "'" + g.NumAchievements + "'," + "'" + g.NumDistinctPlayersCasual + "'," +
                        "'" + g.NumDistinctPlayersHardcore + "')";
      cmd.ExecuteNonQuery();

      Debug.WriteLine("Writing " + g.Title + " to the database took " + watch.ElapsedMilliseconds + " ms.");
      watch.Stop();
      watch.Reset();
      watch.Start();

      if (g.Achievements.Count != 0)
      {
        cmd.CommandText = "INSERT OR REPLACE INTO Achievements(ID, NumAwarded, NumAwardedHardcore, Title, GameID, Description, Points, TrueRatio, Author, DateModified, " +
                            "DateCreated, BadgeID, DisplayOrder, MemAddr) VALUES";

        //add all achievements of the game to the database
        foreach (Achievement a in g.Achievements.Values)
        {
          string description = EscapeSpecialCharacters(a.Description);
          string achTitle = EscapeSpecialCharacters(a.Title);
          string author = EscapeSpecialCharacters(a.Author); //TODO: check if author can even contain '

          cmd.CommandText += "('" + a.ID + "'," + "'" + a.NumAwarded + "'," + "'" + a.NumAwardedHardcore + "'," + "'" + achTitle + "'," + "'" + g.ID + "'," +
                            "'" + description + "'," + "'" + a.Points + "'," + "'" + a.TrueRatio + "'," + "'" + author + "'," +
                            "'" + a.DateModified + "'," + "'" + a.DateCreated + "'," + "'" + a.BadgeID + "'," + "'" + a.DisplayOrder + "'," + "'" + a.MemAddr + "'), ";

        }

        cmd.CommandText = cmd.CommandText.Substring(0, cmd.CommandText.Length - 2);
        cmd.ExecuteNonQuery();
        cmd.Dispose();
        watch.Stop();

        Debug.WriteLine("Writing " + g.Title + " Achievements to the database took " + watch.ElapsedMilliseconds + " ms.");
      }
    }

    /// <summary>
    /// Escapes special characters like ' in strings to use with the database.
    /// </summary>
    /// <param name="original">String to escape special characters in.</param>
    /// <returns>New string with escaped characters.</returns>
    private string EscapeSpecialCharacters(string original)
    {
      if (original == null)
        return "";
      else
        return original.Replace("'", "''");
    }
  }
}