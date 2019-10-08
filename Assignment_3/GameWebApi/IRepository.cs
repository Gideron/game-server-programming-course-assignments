using System;
using System.Threading.Tasks;

public interface IRepository
{
    Task<Player> Get(Guid id);
    Task<Player[]> GetAll();
    Task<Player> Create(Player player);
    Task<Player> Modify(Guid id, ModifiedPlayer player);
    Task<Player> Delete(Guid id);
    Task CreatePlayer(Player player);
    Task<Item> Modify(Guid id, ModifiedItem item);
    Task<Item> GetI(Guid id);
    Task<Item[]> GetAllI();
    Task<Item> DeleteI(Guid id);
    Task CreateItem(Item item);
}