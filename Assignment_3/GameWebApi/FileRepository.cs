using System;
using System.Threading.Tasks;

public class FileRepository : IRepository {
    private string txt_file = "game-dev.txt";
    //File.ReadAllText  File.WriteAllText

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

    /*Task IRepository.CreatePlayer(Player player)
    {
        throw new NotImplementedException();
    }

    Task<Item> IRepository.Modify(Guid id, ModifiedItem item)
    {
        throw new NotImplementedException();
    }

    Task IRepository.CreateItem(Item item)
    {
        throw new NotImplementedException();
    }

    Task<Item> IRepository.GetI(Guid id)
    {
        throw new NotImplementedException();
    }

    Task<Item[]> IRepository.GetAllI()
    {
        throw new NotImplementedException();
    }

    Task<Item> IRepository.DeleteI(Guid id)
    {
        throw new NotImplementedException();
    }*/
}