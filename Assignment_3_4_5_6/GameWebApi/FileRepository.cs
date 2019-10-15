using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;

public class FileRepository : IRepository {
    private string txt_file = "game-dev.txt";
    //File.ReadAllText  File.WriteAllText

    public async Task<Player> Get(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<Player[]> GetAll()
    {
        throw new NotImplementedException();
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