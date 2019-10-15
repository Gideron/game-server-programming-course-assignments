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
    [Route("api/players/{playerId}/items")]
    public class ItemsController : ControllerBase
    {
        private readonly ILogger<ItemsController> _logger;
        private readonly IRepository _repository;

        public ItemsController(ILogger<ItemsController> logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        [Route("{itemId}")]
        public IEnumerable<Item> Get(Guid id)
        {
            return _repository.GetItem(id);
        }

        [HttpGet]
        public IEnumerable<Item[]> GetAll()
        {
            return _repository.GetAllItems();
        }

        [HttpPost]
        public IEnumerable<Item> Create([FromBody] NewItem newItem)
        {
            //if(newItem.Type == Item.ItemType.SWORD && player.Level < 3)
            //    throw error
            Guid id = Guid.NewGuid(); //should be player id

            var item = new Item()
            {
                Level = newItem.Level,
                Type = newItem.Type,
                CreationDate = DateTime.Now
                
            };
            return _repository.CreateItem(id, item);
        }

        [HttpPut]
        [Route("{itemId}")]
        public IEnumerable<Item> GetAll(Guid id, [FromBody] ModifiedItem item)
        {
            return _repository.ModifyItem(id, item);
        }

        [HttpDelete]
        [Route("{itemId}")]
        public IEnumerable<Item> Delete(Guid id)
        {
            return _repository.DeleteItem(id);
        }
    }
}
