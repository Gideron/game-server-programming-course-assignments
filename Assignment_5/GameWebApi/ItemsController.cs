using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;

[Route("api/players/{playerId}/items")]
[ApiController]
public class ItemsController
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
        //return await _repository.Get(id);
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route("")]
    public async Task<Item[]> GetAll()
    {
        //gets player with playerId and returns all items
        Console.WriteLine("GetALL");
        //return await _repository.GetAllI();
        throw new NotImplementedException();
    }

    [HttpPost]
    [Route("")]
    public async Task<Item> Create(NewItem newItem)
    {
        /*_logger.LogInformation("Creating item with name " + newItem.Name);
        var item = new Item()
        {
            Id = Guid.NewGuid(),
            Name = newItem.Name,
            CreationTime = DateTime.Now,
            Type = newItem.Type
        };
        await _repository.CreateItem(item);
        return item;*/
        throw new NotImplementedException();
    }

    [HttpPut]
    [Route("{itemId}")]
    public async Task<Item> Modify(Guid id, ModifiedItem item)
    {
        //return await _repository.Modify(id, item);
        throw new NotImplementedException();
    }

    [HttpDelete]
    [Route("{itemId}")]
    public async Task<Item> Delete(Guid id)
    {
        //return await _repository.DeleteI(id);
        throw new NotImplementedException();
    }
}