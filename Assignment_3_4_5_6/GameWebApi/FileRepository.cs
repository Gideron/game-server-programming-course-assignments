using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json; 

public class FileRepository : IRepository {
    private string filePath = "game-dev.txt";
    //File.ReadAllText  File.WriteAllText

    public async Task<Player> Get(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<Player> GetWithName(string name)
    {
        throw new NotImplementedException();
    }

    public async Task<Player[]> GetAll()
    {
        if (!File.Exists(filePath))
            throw new NotImplementedException("Could not find file");

        try
        {
            string responseBody = File.ReadAllText(filePath);
            PlayerList pl = JsonConvert.DeserializeObject<PlayerList>(responseBody);
            return pl.Players.ToArray();
        }
        catch
        {
            throw new NotImplementedException("Could not get players");
        }
        throw new NotImplementedException("Could not get players");
    }

    public async Task<Player[]> GetAllWithScoreOverX(int score)
    {
        throw new NotImplementedException();
    }

    public async Task<Player> Create(Player player)
    {
        /*if (!File.Exists(filePath))
        {
            throw new NotImplementedException();
        }

        try
        {
            string responseBody = File.ReadAllText(filePath);
            PlayerList pl = JsonConvert.DeserializeObject<PlayerList>(responseBody);
            pl.Players.Add(player);
            string newPlayerList = JsonConvert.SerializeObject(pl);
            File.WriteAllText(filePath, newPlayerList, Encoding.UTF8);
            return player;
        }
        catch
        {
            throw new NotImplementedException("Could not get players");
        }*/

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