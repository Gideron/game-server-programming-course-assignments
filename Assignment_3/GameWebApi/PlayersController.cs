using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;
[Route("api/[controller]")]
[ApiController]
public class PlayersController
{
    private readonly ILogger<PlayersController> _logger;
    private readonly IRepository _repository;

    public PlayersController(ILogger<PlayersController> logger, IRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    [HttpGet]
    [Route("{playerId}")]
    public async Task<Player> GetAsync(Guid id)
    {
        return await _repository.Get(id);
    }

    [HttpGet]
    [Route("")]
    public async Task<Player[]> GetAllAsync()
    {
        return await _repository.GetAll();
    }

    [HttpPost]
    [Route("")]
    [ValidateModel]
    public async Task<Player> CreateAsync(NewPlayer player)
    {
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
    public async Task<Player> ModifyAsync(Guid id, ModifiedPlayer player)
    {
        return await _repository.Modify(id, player);
    }

    [HttpDelete]
    [Route("{playerId}")]
    public async Task<Player> DeleteAsync(Guid id)
    {
        return await _repository.Delete(id);
    }
}