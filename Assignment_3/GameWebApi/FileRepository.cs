using System;
using System.Threading.Tasks;

public class FileRepository : IRepository {
    private string txt_file = "game-dev.txt";
    //File.ReadAllText  File.WriteAllText

    //public Player Get(Guid id)
    //{
    //    //return player with Guid
    //}

    //public Player[] GetAll()
    //{
    //    //return all players
    //}

    //public Player Create(Player player)
    //{
    //    //create/write new player
    //}

    //public Player Modify(Guid id, ModifiedPlayer player)
    //{
    //    //update player with Guid
    //}

    //public Player Delete(Guid id)
    //{
    //    //delete player with Guid
    //}

    Task<Player> IRepository.Get(Guid id)
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

    Task<Player> IRepository.Modify(Guid id, ModifiedPlayer player)
    {
        throw new NotImplementedException();
    }

    Task<Player> IRepository.Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    Task IRepository.CreatePlayer(Player player)
    {
        throw new NotImplementedException();
    }
}