using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Player
{
    public Player()
    {
        Items = new List<Item>();
    }
    [BsonId]
    public ObjectId ObjId { get; set; }
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Score { get; set; }
    public int Level { get; set; }
    public bool IsBanned { get; set; }
    public DateTime CreationDate { get; set; }
    public List<Item> Items { get; set; }
}

public class PlayerList {
    public PlayerList()
    {
        Players = new List<Player>();
    }
    public List<Player> Players { get; set; }
}