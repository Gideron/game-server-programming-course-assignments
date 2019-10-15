using System;
using System.Collections.Generic;
using MongoDB.Bson;

public class Player
{
    public Player()
    {
        Items = new List<Item>();
    }
    //[BsonId]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Score { get; set; }
    public int Level { get; set; }
    public bool IsBanned { get; set; }
    public DateTime CreationTime { get; set; }
    public List<Item> Items { get; set; }
}