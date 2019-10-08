using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;

[Route("api/players")]
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
    public async Task<Player> Get(Guid id)
    {
        return await _repository.Get(id);
    }

    [HttpGet]
    [Route("")]
    public async Task<Player[]> GetAll()
    {
        return await _repository.GetAll();
    }

    [HttpPost]
    [Route("")]
    public async Task<Player> Create(NewPlayer newPlayer)
    {
        _logger.LogInformation("Creating player with name " + newPlayer.Name);
        var player = new Player()
        {
            Id = Guid.NewGuid(),
            Name = newPlayer.Name,
            CreationTime = DateTime.Now
        };
        await _repository.Create(player);
        return player;
    }

    [HttpPut]
    [Route("{playerId}")]
    public async Task<Player> Modify(Guid id, ModifiedPlayer player)
    {
        return await _repository.Modify(id, player);
    }

    [HttpDelete]
    [Route("{playerId}")]
    public async Task<Player> Delete(Guid id)
    {
        return await _repository.Delete(id);
    }
}