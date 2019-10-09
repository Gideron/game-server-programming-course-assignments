using System;
using System.Threading.Tasks;

namespace api
{
    public class FileRepository : IRepository
    {
        private string txt_file = "game-score.txt";
        Task<Player> IRepository.Get(string name)
        {
            throw new NotImplementedException();
        }

        Task<Player[]> IRepository.GetAll()
        {
            throw new NotImplementedException();
        }

        Task<Player> IRepository.Create(Player player)
        {
            throw new NotImplementedException();
        }

        Task<Player> IRepository.Modify(string name, ModifiedPlayer player)
        {
            throw new NotImplementedException();
        }

        Task<Player> IRepository.Delete(string name)
        {
            throw new NotImplementedException();
        }
    }
}
