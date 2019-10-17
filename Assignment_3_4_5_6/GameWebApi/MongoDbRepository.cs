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
        var filter = Builders<Player>.Filter.Eq(p => p.Id, id);
        return await _collection.Find(filter).FirstAsync();
        //throw new NotImplementedException();
    }

    public async Task<Player> GetWithName(string name)
    {
        var filter = Builders<Player>.Filter.Eq(p => p.Name, name);
        return await _collection.Find(filter).FirstAsync();
        //throw new NotImplementedException();
    }

    public async Task<Player[]> GetAll()
    {
        var players = await _collection.Find(new BsonDocument()).ToListAsync();
        return players.ToArray();
        //throw new NotImplementedException();
    }

    public async Task<Player[]> GetAllWithScoreOverX(int minScore)
    {
        var filter = Builders<Player>.Filter.Gte(p => p.Score, minScore);
        var players = await _collection.Find(filter).ToListAsync();
        return players.ToArray();
        //throw new NotImplementedException();
    }

    public async Task<Player> Create(Player player)
    {
        await _collection.InsertOneAsync(player);
        return player;
        //throw new NotImplementedException();
    }

    public async Task<Player> Modify(Guid id, ModifiedPlayer player)
    {
        Player modifiedPlayer = Get(id).Result;
        modifiedPlayer.Score = player.Score;

        FilterDefinition<Player> filter = Builders<Player>.Filter.Eq(p => p.Id, id);
        await _collection.ReplaceOneAsync(filter, modifiedPlayer);
        return modifiedPlayer;
        //throw new NotImplementedException();
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
        FilterDefinition<Player> filter = Builders<Player>.Filter.Eq(p => p.Id, id);
        var update = Builders<Player>.Update.Push("Items", item);
        await _collection.FindOneAndUpdateAsync(filter, update);
        return item;
        //throw new NotImplementedException();
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