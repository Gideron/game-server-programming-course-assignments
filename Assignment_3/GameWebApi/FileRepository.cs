public class FileRepository : IRepository {
    private string txt_file = "game-dev.txt";
    //File.ReadAllText  File.WriteAllText

    public async Task<Player> Get(Guid id){
        //return player with Guid
    }

    public async Task<Player[]> GetAll(){
        //return all players
    }

    public async Task<Player> Create(Player player){
        //create/write new player
    }

    public async Task<Player> Modify(Guid id, ModifiedPlayer player){
        //update player with Guid
    }
    
    public async Task<Player> Delete(Guid id){
        //delete player with Guid
    }
}