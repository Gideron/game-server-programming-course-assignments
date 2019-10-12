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
        private string filePath = "game-score.txt";
        //File.ReadAllText  File.WriteAllText

        Task<Player> IRepository.Get(string name)
        {
            throw new NotImplementedException();
        }

        async Task<Player[]> IRepository.GetAll()
        {
            if (!File.Exists(filePath))
            {
                //file not found
                throw new NotImplementedException();
            }

            try	
            {
                Console.WriteLine("-----------1111111111------------");
                string responseBody = File.ReadAllText(filePath);
                Console.WriteLine("responseBody: " + responseBody);
                Console.WriteLine("-----------2222222222------------");
                //convert response to BikeRentalStationList
                PlayerList pList = JsonConvert.DeserializeObject<PlayerList>(responseBody);
                foreach(Player p in pList.players){
                    Console.WriteLine(p.Name + "\n");
                }
                Console.WriteLine("-----------3333333333------------");
                
                return pList.players.ToArray();
            }  
            catch
            {
                throw new NotImplementedException("Could not get players");
            }
        }

        Task<Player> IRepository.Create(Player player)
        {
            if (!File.Exists(filePath))
            {
                //file not found
                throw new NotImplementedException();
            }
            string playerToCreate = JsonConvert.SerializeObject(player);
            File.AppendAllText(filePath, playerToCreate, Encoding.UTF8);

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
        public List<Player> players { get; set; }
    }
}
