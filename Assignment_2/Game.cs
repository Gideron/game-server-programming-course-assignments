using System;
using System.Collections.Generic;
using System.Linq;

public class Game<T> where T : IPlayer
{
    private List<T> _players;

    public Game(List<T> players) {
        _players = players;
    }

    public T[] GetTop10Players() {
        _players.Sort((p, q) => p.Score.CompareTo(q.Score));
        return _players.GetRange(0, 10).ToArray();
    }
}