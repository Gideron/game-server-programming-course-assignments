using System;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json; 

namespace api
{
    public class FileRepository : IRepository
    {
        private string filePath = "game-score.json";
        //File.ReadAllText  File.WriteAllText

        Task<Player> IRepository.Get(string name)
        {
            throw new NotImplementedException();
        }

        async Task<string> IRepository.GetAll()
        {
            if (!File.Exists(filePath))
                throw new NotImplementedException();

            try	{
                string responseBody = File.ReadAllText(filePath);
                return responseBody;
            } catch {
                throw new NotImplementedException("Could not get players");
            }
        }

        async Task<Player> IRepository.Create(Player player)
        {
            if (!File.Exists(filePath))
            {
                throw new NotImplementedException();
            }

            try	{
                string responseBody = File.ReadAllText(filePath);
                PlayerList pl = JsonConvert.DeserializeObject<PlayerList>(responseBody);
                pl.Players.Add(player);
                string newPlayerList = JsonConvert.SerializeObject(pl);
                File.WriteAllText(filePath, newPlayerList, Encoding.UTF8);
                return player;
            } catch {
                throw new NotImplementedException("Could not get players");
            }

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

    public class PlayerList {
        public List<Player> Players { get; set; }
    }
}
