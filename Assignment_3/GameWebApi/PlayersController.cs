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
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route()]
    public Task<Player[]> GetAll(){
        throw new NotImplementedException();
    }

    [HttpPost]
    [Route("")]
    [ValidateModel]
    public Task<Player> Create(NewPlayer player){
        throw new NotImplementedException();
        /*_logger.LogInformation("Creating player with name " + newPlayer.Name);
        var player = new Player()
        {
            Id = Guid.NewGuid(),
            Name = newPlayer.Name,
            CreationTime = DateTime.Now()
        };
        await _repository.CreatePlayer(player);
        return player;*/
    }

    [HttpUpdate]
    [Route("{playerId}")]
    public Task<Player> Modify(Guid id, ModifiedPlayer player){
        throw new NotImplementedException();
    }

    [HttpDelete]
    [Route("{playerId}")]
    public Task<Player> Delete(Guid id){
        throw new NotImplementedException();
    }
}