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

        [HttpPatch]
        [Route("{playerId}")]
        public async Task<Player> Modify(Guid id, [FromBody] ModifiedPlayer player)
        {
            Console.WriteLine("================\n============");
            Console.WriteLine("guid: " + id);
            return await _repository.Modify(id, player);
        }

        [HttpDelete]
        [Route("{playerId}")]
        public async Task<Player> Delete(Guid id)
        {
            return await _repository.Delete(id);
        }
    }
}
