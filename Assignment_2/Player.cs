using System;
using System.Collections.Generic;

public class Player : IPlayer
{
    public Guid Id { get; set; }
    public int Score { get; set; }
    public List<Item> Items { get; set; }

    public Item GetHighestLevelItem(){
        Items.Sort((p, q) => p.Level.CompareTo(q.Level));
        return Items[0];;
    }
}