using System;
using System.Collections.Generic;
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
      cmd.CommandText = "CREATE TABLE IF NOT EXISTS Games ( ID INTEGER PRIMARY KEY ASC, Title TEXT, ConsoleID INTEGER, ForumTopicID INTEGER, Flags TEXT, ImageIconString TEXT, " +
                        "ImageTitleString TEXT, ImageIngameString TEXT, ImageBoxArtString TEXT, Publisher TEXT, Developer TEXT, Genre TEXT, Released TEXT, " +
                        "IsFinal BOOLEAN, ConsoleName TEXT, RichPresencePatch TEXT, NumAchievements INTEGER, NumDistinctPlayersCasual INTEGER, NumDistinctPlayersHardcore INTEGER);";
      cmd.ExecuteNonQuery();

      cmd.CommandText = "CREATE TABLE IF NOT EXISTS Achievements ( ID INTEGER PRIMARY KEY, NumAwarded INTEGER, NumAwardedHardcore INTEGER, Title TEXT, GameID INTEGER, " +
                        "Description TEXT, Points INTEGER, TrueRatio INTEGER, Author TEXT, DateModified TEXT, DateCreated TEXT, BadgeID INTEGER, DisplayOrder INTEGER, MemAddr TEXT);";
      cmd.ExecuteNonQuery();
      cmd.Dispose();
    }

    public List<Game> GetGames()
    {
      SQLiteCommand cmd = new SQLiteCommand(Connection);
      cmd.CommandText = "SELECT * FROM Games;";
      SQLiteDataReader reader = cmd.ExecuteReader();

      List<Game> gameList = new List<Game>();

      while (reader.Read())
      {
          gameList.Add(new Game(int.Parse(reader[0].ToString()), reader[1].ToString(), int.Parse(reader[2].ToString()), int.Parse(reader[3].ToString()), reader[4].ToString(), reader[5].ToString(), 
                        reader[6].ToString(), reader[7].ToString(), reader[8].ToString(), reader[9].ToString(), reader[10].ToString(), reader[11].ToString(), reader[12].ToString(), 
                        bool.Parse(reader[13].ToString()), reader[14].ToString(), reader[15].ToString(), int.Parse(reader[16].ToString()), int.Parse(reader[17].ToString()), int.Parse(reader[18].ToString())));
      }

      reader.Dispose();

      foreach(Game g in gameList)
      {
        cmd.CommandText = "SELECT * FROM Achievements WHERE GameID = " + g.ID + ";";
        reader = cmd.ExecuteReader();

        Dictionary<int, Achievement> achievementList = new Dictionary<int, Achievement>();
        while(reader.Read())
        {
          //skip 4 because it is the gameID, which only exists in the DB.
          achievementList.Add(int.Parse(reader[0].ToString()), new Achievement(int.Parse(reader[0].ToString()), int.Parse(reader[1].ToString()), int.Parse(reader[2].ToString()), reader[3].ToString(), 
                              reader[5].ToString(), int.Parse(reader[6].ToString()), int.Parse(reader[7].ToString()), reader[8].ToString(), reader[9].ToString(), reader[10].ToString(), 
                              int.Parse(reader[11].ToString()), int.Parse(reader[12].ToString()), reader[13].ToString()));
        }

        g.Achievements = achievementList;
      }

      return gameList;
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

      cmd.CommandText = "INSERT OR REPLACE INTO Games(ID, Title, ConsoleID, ForumTopicID, Flags, ImageIconString, ImageTitleString, ImageIngameString, ImageBoxArtString, " +
                        "Publisher, Developer, Genre, Released, IsFinal, ConsoleName, RichPresencePatch, NumAchievements, NumDistinctPlayersCasual, " +
                        "NumDistinctPlayersHardcore) " +
                        "VALUES('" + g.ID + "'," + "'" + title + "'," + "'" + g.ConsoleID + "'," + "'" + g.ForumTopicID + "'," + "'" + g.Flags + "'," + "'" + g.ImageIconString + "'," +
                        "'" + g.ImageTitleString + "'," + "'" + g.ImageIngameString + "'," + "'" + g.ImageBoxArtString + "'," + "'" + publisher + "'," +
                        "'" + developer + "'," + "'" + genre + "'," + "'" + g.Released + "'," + "'" + g.IsFinal + "'," + "'" + g.ConsoleName + "'," +
                        "'" + richPresencePatch + "'," + "'" + g.NumAchievements + "'," + "'" + g.NumDistinctPlayersCasual + "'," +
                        "'" + g.NumDistinctPlayersHardcore + "')";
      cmd.ExecuteNonQuery();

      Debug.WriteLine("Writing " + g.Title + " to the database took " + watch.ElapsedMilliseconds + " ms.");
      watch.Stop();
      watch.Reset();
      watch.Start();

      if (g.Achievements != null || g.Achievements.Count != 0)
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