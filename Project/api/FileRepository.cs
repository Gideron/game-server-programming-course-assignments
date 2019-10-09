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

        Task<Player[]> IRepository.GetAll()
        {
            /*if (!File.Exists(filePath))
            {
                //file not found
                throw new NotImplementedException();
            }

            string readText = File.ReadAllText(filePath);
            Console.WriteLine(readText);
            var pList = JsonConvert.DeserializeObject<List<Player>>(readText).ToArray();
            return new Task(pList);*/
            
            throw new NotImplementedException();
        }

        Task<Player> IRepository.Create(Player player)
        {
            /*if (!File.Exists(filePath))
            {
                //file not found
                throw new NotImplementedException();
            }
            
            string appendText = "This is extra text" + Environment.NewLine;
            File.AppendAllText(filePath, appendText, Encoding.UTF8);*/
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
