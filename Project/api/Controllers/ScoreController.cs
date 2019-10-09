using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;
using api;

[Route("api/players")]
[ApiController]
public class ScoreController
{
    private readonly ILogger<ScoreController> _logger;
    private readonly IRepository _repository;

    public ScoreController(ILogger<ScoreController> logger, IRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    [HttpGet]
    [Route("{playerName}")]
    public async Task<Player> Get(string name)
    {
        return await _repository.Get(name);
    }

    [HttpGet]
    [Route("")]
    public async Task<Player[]> GetAll()
    {
        return await _repository.GetAll();
    }

    [HttpPost]
    [Route("{application/Json}")]
    public async Task<Player> Create([FromBody] NewPlayer newPlayer)
    {
        _logger.LogInformation("Creating player with name " + newPlayer.Name);
        var player = new Player()
        {
            Name = newPlayer.Name,
            Score = newPlayer.Score
        };
        await _repository.Create(player);
        return player;
    }

    [HttpPut]
    [Route("{playerName}")]
    public async Task<Player> Modify(string name, ModifiedPlayer player)
    {
        return await _repository.Modify(name, player);
    }

    [HttpDelete]
    [Route("{playerName}")]
    public async Task<Player> Delete(string name)
    {
        return await _repository.Delete(name);
    }
}