public class PlayersController {
    public Task<Player> Get(Guid id);
    public Task<Player[]> GetAll();
    public Task<Player> Create(NewPlayer player);
    public Task<Player> Modify(Guid id, ModifiedPlayer player);
    public Task<Player> Delete(Guid id);
}