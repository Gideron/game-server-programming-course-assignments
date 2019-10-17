using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;

public interface IRepository
{
    //Player
    Task<Player> Get(Guid id);
    Task<Player[]> GetAll();
    Task<Player> Create(Player player);
    Task<Player> Modify(Guid id, ModifiedPlayer player);
    Task<Player> Delete(Guid id);
    Task<Player> GetWithName(string id);

    //Item
    Task<Item> GetItem(Guid id);
    Task<Item[]> GetAllItems();
    Task<Item> CreateItem(Guid id, Item item);
    Task<Item> ModifyItem(Guid id, ModifiedItem item);
    Task<Item> DeleteItem(Guid id);
}