﻿using System.Collections.Generic;

namespace RAToolSetWPF
{
  /// <summary>
  /// Represents a console with games.
  /// </summary>
  class Console
  {
    private int _id;
    private string _name;
    private List<Game> _games;

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
    public List<Game> Games
    {
      get { return _games; }
      private set { _games = value; }
    }

    /// <summary>
    /// Ctor.
    /// </summary>
    public Console(int id, string name)
    {
      ID = id;
      Name = name;
      Games = new List<Game>();
    }

    /// <summary>
    /// Adds a game to this console.
    /// </summary>
    /// <param name="game">Game to add.</param>
    public void AddGame(Game game)
    {
      foreach(Game g in Games)
      {
        if (g.ID == game.ID)
          return; //do not add probably already fetched
      }

      Games.Add(game);
    }
  }
}