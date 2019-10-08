using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System;

[Route("api/[controller]")]
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
    public async Task<Item> GetAsync(Guid id)
    {
        
        return await _repository.GetI(id);
    }

    [HttpGet]
    [Route("")]
    public async Task<Item[]> GetAllAsync()
    {
        Console.WriteLine("GetALL");
        return await _repository.GetAllI();
    }

    [HttpPost]
    [Route("")]
    public async Task<Item> CreateAsync(NewItem newItem)
    {
        _logger.LogInformation("Creating item with name " + newItem.Name);
        var item = new Item()
        {
            Id = Guid.NewGuid(),
            Name = newItem.Name,
            CreationTime = DateTime.Now,
            Type = newItem.Type
        };
        await _repository.CreateItem(item);
        return item;
    }

    [HttpPut]
    [Route("{itemId}")]
    public async Task<Item> ModifyAsync(Guid id, ModifiedItem item)
    {
        return await _repository.Modify(id, item);
    }

    [HttpDelete]
    [Route("{itemId}")]
    public async Task<Item> DeleteAsync(Guid id)
    {
        return await _repository.Delete(id);
    }
}