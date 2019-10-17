using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json; 

public class FileRepository : IRepository {
    private string filePath = "game-dev.json";

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
            Console.WriteLine("-----GetAll TRY--------");
            string responseBody = File.ReadAllText(filePath);
            Console.WriteLine("-----file read -> deserialize--------");
            PlayerList pl = JsonConvert.DeserializeObject<PlayerList>(responseBody);
            Console.WriteLine("-----return--------");
            return pl.Players.ToArray();
        }
        catch
        {
            throw new NotImplementedException("Could not get players");
        }
    }

    public async Task<Player[]> GetAllWithScoreOverX(int score)
    {
        throw new NotImplementedException();
    }

    public async Task<Player[]> GetTopPlayers()
    {
        throw new NotImplementedException();
    }

    public async Task<Player> Create(Player player)
    {
       if (!File.Exists(filePath))
            throw new NotImplementedException("Could not find file");
    
        try
        {
            string responseBody = File.ReadAllText(filePath);
            PlayerList pl = JsonConvert.DeserializeObject<PlayerList>(responseBody);
            pl.Players.Add(player);
            string newPlayerList = JsonConvert.SerializeObject(pl);
            File.WriteAllText(filePath, newPlayerList);
            return player;
        }
        catch
        {
            throw new NotImplementedException("Could not create players");
        }

        throw new NotImplementedException();
    }

    public async Task<Player> Modify(Guid id, ModifiedPlayer player)
    {
        if (!File.Exists(filePath))
            throw new NotImplementedException("Could not find file");

        try
        {
            string responseBody = File.ReadAllText(filePath);
            PlayerList pl = JsonConvert.DeserializeObject<PlayerList>(responseBody);

            Player modified = pl.Players.Find(p => p.Id == id);
            modified.Score = player.Score;

            List<Player> updatedPlayers = new List<Player>();
            updatedPlayers = pl.Players.FindAll(p => p.Id != id);
            updatedPlayers.Add(modified);
            pl.Players = updatedPlayers;

            string newPlayerList = JsonConvert.SerializeObject(pl);
            File.WriteAllText(filePath, newPlayerList);
            return modified;
        }
        catch
        {
            throw new NotImplementedException("Could not delete player");
        }
    }

    public async Task<Player> AddPlayerScore(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<Player> Delete(Guid id)
    {
        if (!File.Exists(filePath))
            throw new NotImplementedException("Could not find file");

        try
        {
            string responseBody = File.ReadAllText(filePath);
            PlayerList pl = JsonConvert.DeserializeObject<PlayerList>(responseBody);
            Player removed = pl.Players.Find(p => p.Id == id);
            List<Player> remainingPlayers = new List<Player>();
            remainingPlayers = pl.Players.FindAll(p => p.Id != id);
            pl.Players = remainingPlayers;
            string newPlayerList = JsonConvert.SerializeObject(pl);
            File.WriteAllText(filePath, newPlayerList);
            return removed;
        }
        catch
        {
            throw new NotImplementedException("Could not delete player");
        }
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