using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace GameWebApi.Controllers
{
    [ApiController]
    [Route("api/players")]
    public class PlayersController : ControllerBase
    {
        private readonly ILogger<PlayersController> _logger;
        private readonly IRepository _repository;

        public PlayersController(ILogger<PlayersController> logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        [Route("{playerId:guid}")]
        public async Task<Player> Get(Guid playerId)
        {
            return await _repository.Get(playerId);
        }

        //assignment 6 query 1
        [HttpGet]
        [Route("{minScore:int}")]
        public async Task<Player[]> GetAllWithScoreOverX(int minScore)
        {
            return await _repository.GetAllWithScoreOverX(minScore);
        }

        //assignment 6 query 2
        [HttpGet]
        [Route("{name}")]
        public async Task<Player> GetWithName(string name)
        {
            return await _repository.GetWithName(name);
        }

        [HttpGet]
        [Route("")]
        public async Task<Player[]> GetAll()
        {
            return await _repository.GetAll();
        }

        //assignment 6 query 10
        [HttpGet]
        [Route("top")]
        public async Task<Player[]> GetTopPlayers()
        {
            return await _repository.GetTopPlayers();
        }

        [HttpPost]
        public async Task<Player> Create([FromBody] NewPlayer newPlayer)
        {
            var player = new Player()
            {
                Id = Guid.NewGuid(),
                Name = newPlayer.Name,
                CreationDate = DateTime.Now
            };
            return await _repository.Create(player);
        }

        //assignment 6 query 6
        [HttpPatch]
        [Route("{playerId:guid}")]
        public async Task<Player> Modify(Guid playerId, [FromBody] ModifiedPlayer player)
        {
            return await _repository.Modify(playerId, player);
        }

        //assignment 6 query 7
        [HttpPut]
        [Route("{playerId:guid}")]
        public async Task<Player> AddScore(Guid playerId)
        {
            return await _repository.AddPlayerScore(playerId);
        }

        [HttpDelete]
        [Route("{playerId}")]
        public async Task<Player> Delete(Guid id)
        {
            return await _repository.Delete(id);
        }
    }
}
