using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;

using MongoDB.Bson;
using MongoDB.Driver;

public class MongoDbRepository : IRepository {

    private readonly IMongoCollection<Player> _collection;
    private readonly IMongoCollection<BsonDocument> _bsonDocumentCollection;

    public MongoDbRepository()
    {
        var mongoClient = new MongoClient("mongodb://localhost:27017");
        var database = mongoClient.GetDatabase("assignment_db");
        _collection = database.GetCollection<Player>("players");
        _bsonDocumentCollection = database.GetCollection<BsonDocument>("players");
    }

    public async Task<Player> Get(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<Player[]> GetAll()
    {
        var players = await _collection.Find(new BsonDocument()).ToListAsync();
        //Console.WriteLine(players[0]);
        Console.WriteLine("-------------------------------------\n--------------------------------------");
        Console.WriteLine(players);
        return players.ToArray();

        //throw new NotImplementedException();
    }

    public async Task<Player> Create(Player player)
    {
        throw new NotImplementedException();
    }

    public async Task<Player> Modify(Guid id, ModifiedPlayer player)
    {
        throw new NotImplementedException();
    }

    public async Task<Player> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<Item> GetItem(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<Item[]> GetAllItems()
    {
        throw new NotImplementedException();
    }

    public async Task<Item> CreateItem(Guid id, Item item)
    {
        throw new NotImplementedException();
    }

    public async Task<Item> ModifyItem(Guid id, ModifiedItem item)
    {
        throw new NotImplementedException();
    }

    public async Task<Item> DeleteItem(Guid id)
    {
        throw new NotImplementedException();
    }
}