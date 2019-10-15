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
        public IEnumerable<Player> Get(Guid id)
        {
            return _repository.Get(id);
        }

        [HttpGet]
        public IEnumerable<Player[]> GetAll()
        {
            return _repository.GetAll();
        }

        [HttpPost]
        public IEnumerable<Player> Create([FromBody] NewPlayer newPlayer)
        {
            var player = new Player()
            {
                Id = Guid.NewGuid(),
                Name = newPlayer.Name,
                CreationTime = DateTime.Now
            };
            return _repository.Create(player);
        }

        [HttpPut]
        [Route("{playerId}")]
        public IEnumerable<Player> GetAll(Guid id, [FromBody] ModifiedPlayer player)
        {
            return _repository.Modify(id, player);
        }

        [HttpDelete]
        [Route("{playerId}")]
        public IEnumerable<Player> Delete(Guid id)
        {
            return _repository.Delete(id);
        }
    }
}
