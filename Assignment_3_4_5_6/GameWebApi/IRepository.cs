using System;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;

public interface IRepository
{
    //Player
    IEnumerable<Player> Get(Guid id);
    IEnumerable<Player[]> GetAll();
    IEnumerable<Player> Create(Player player);
    IEnumerable<Player> Modify(Guid id, ModifiedPlayer player);
    IEnumerable<Player> Delete(Guid id);

    //Item
    IEnumerable<Item> GetItem(Guid id);
    IEnumerable<Item[]> GetAllItems();
    IEnumerable<Item> CreateItem(Guid id, Item item);
    IEnumerable<Item> ModifyItem(Guid id, ModifiedItem item);
    IEnumerable<Item> DeleteItem(Guid id);
}