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
        public async Task<Item> Get(Guid id)
        {
            return await _repository.GetItem(id);
        }

        [HttpGet]
        public async Task<Item[]> GetAll()
        {
            return await _repository.GetAllItems();
        }

        [HttpPost]
        public async Task<Item> Create([FromBody] NewItem newItem)
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
            return await _repository.CreateItem(id, item);
        }

        [HttpPut]
        [Route("{itemId}")]
        public async Task<Item> GetAll(Guid id, [FromBody] ModifiedItem item)
        {
            return await _repository.ModifyItem(id, item);
        }

        [HttpDelete]
        [Route("{itemId}")]
        public async Task<Item> Delete(Guid id)
        {
            return await _repository.DeleteItem(id);
        }
    }
}
