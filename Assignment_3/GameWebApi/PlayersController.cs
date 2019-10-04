[Route("api/[controller]")]
[ApiController]
public class PlayersController {
    private readonly ILogger<PlayersController> _logger;
    private readonly IRepository _repository;

    public PlayersController(ILogger<PlayersController> logger, IRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }
    
    [HttpGet]
    [Route("{playerId}")]
    public Task<Player> Get(Guid id){
        return await _repository.Get(id);
    }

    [HttpGet]
    [Route()]
    public Task<Player[]> GetAll(){
        return await _repository.GetAll();
    }

    [HttpPost]
    [Route("")]
    [ValidateModel]
    public Task<Player> Create(NewPlayer player){
        _logger.LogInformation("Creating player with name " + newPlayer.Name);
        var player = new Player()
        {
            Id = Guid.NewGuid(),
            Name = newPlayer.Name,
            CreationTime = DateTime.Now()
        };
        await _repository.CreatePlayer(player);
        return player;
    }

    [HttpUpdate]
    [Route("{playerId}")]
    public Task<Player> Modify(Guid id, ModifiedPlayer player){
        return await _repository.Modify(id, player);
    }

    [HttpDelete]
    [Route("{playerId}")]
    public Task<Player> Delete(Guid id){
        return await _repository.Delete(id);
    }
}