using System;
using System.Threading.Tasks;

namespace api
{
    public interface IRepository
    {
        Task<Player> Get(string name);
        Task<Player[]> GetAll();
        Task<Player> Create(Player player);
        Task<Player> Modify(string name, ModifiedPlayer player);
        Task<Player> Delete(string name);
    }
}
