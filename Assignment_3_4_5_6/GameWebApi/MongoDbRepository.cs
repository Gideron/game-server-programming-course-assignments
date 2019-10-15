using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;

using MongoDB.Bson;
using MongoDB.Driver;

public class MongoDbRepository : IRepository {
    private string txt_file = "game-dev.txt";

    public IEnumerable<Player> Get(Guid id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Player[]> GetAll()
    {
        MongoClient client = new MongoClient();
        //MongoServer server = client.GetServer();
        MongoDatabase db = client.GetDatabase("assignment_db");
        MongoCollection<Player> collection = db.GetCollection<Player>("players");

        throw new NotImplementedException();
    }

    public IEnumerable<Player> Create(Player player)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Player> Modify(Guid id, ModifiedPlayer player)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Player> Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Item> GetItem(Guid id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Item[]> GetAllItems()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Item> CreateItem(Guid id, Item item)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Item> ModifyItem(Guid id, ModifiedItem item)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Item> DeleteItem(Guid id)
    {
        throw new NotImplementedException();
    }
}