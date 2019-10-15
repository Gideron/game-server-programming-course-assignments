using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;

public class FileRepository : IRepository {
    private string txt_file = "game-dev.txt";
    //File.ReadAllText  File.WriteAllText

    public IEnumerable<Player> Get(Guid id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Player[]> GetAll()
    {
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