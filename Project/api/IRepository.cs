using System;
using System.Threading.Tasks;

namespace api
{
    public interface IRepository
    {
        Task<Player> Get(string name);
        Task<string> GetAll();
        Task<Player> Create(Player player);
        Task<Player> Modify(string name, ModifiedPlayer player);
        Task<Player> Delete(string name);
    }
}
