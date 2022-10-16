using Microsoft.AspNetCore.Mvc;
using Week3.Domain.Entities;
using Week3.Domain.Interfaces;

namespace Week3.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductRepository _repository;

    public ProductController(IProductRepository repository)
    {
        this._repository = repository;
    }
    
    // GET: api/product
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _repository.GetAll());
    }
    
    // GET: api/project/1
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var p = await _repository.GetById(id);
        return p == null ? Ok(p) : NotFound();
    }

    // POST: api/project
    [HttpPost]
    public async Task<IActionResult> Post(Product product)
    {
        var p = await _repository.Add(product);
        return CreatedAtAction(nameof(Get), new { id = p.Id }, p.Id);
    }
    
    // PUT: api/project/1
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(Product product, int id)
    {
        return id == product.Id ? Ok(await _repository.Update(product)) : BadRequest();
    }
    
    // DELETE: api/project
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var p = await _repository.GetById(id);
        return p == null ? NotFound() : Ok(await _repository.Remove(p));
    }
    
    // POST: api/project/range
    [HttpPost("range")]
    public async Task<IActionResult> PostRange(IEnumerable<Product> products)
    {
        var ids = await _repository.AddRange(products);
        return CreatedAtAction(nameof(GetAll), ids, ids);
    }
    
    // PUT: api/project/range
    [HttpPut("range")]
    public async Task<IActionResult> PutRange(IEnumerable<Product> products)
    {
        return Ok(await _repository.UpdateRange(products));
    }
    
    // DELETE: api/project/range
    [HttpDelete("range")]
    public async Task<IActionResult> DeleteRange(IEnumerable<Product> products)
    {
        return Ok(await _repository.RemoveRange(products));
    }
}