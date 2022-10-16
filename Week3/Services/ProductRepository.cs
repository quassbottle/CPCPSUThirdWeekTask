using System.Linq.Expressions;
using Week3.Domain.Entities;
using Week3.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Week3.Migration;

namespace Week3.Services;

public class ProductRepository : IProductRepository
{
    private ProductContext _context;

    public ProductRepository(ProductContext context)
    {
        this._context = context;
    }
    
    public async Task<Product> GetById(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task<IEnumerable<Product>> GetAll()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<IEnumerable<Product>> Find(Expression<Func<Product, bool>> exp)
    {
        return await _context.Products.Where(exp).ToListAsync();
    }

    public async Task<Product> Add(Product entity)
    {
        await _context.Products.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<Product> Update(Product entity)
    {
        _context.Products.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<Product> Remove(Product entity)
    {
        _context.Products.Remove(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<IEnumerable<Product>> AddRange(IEnumerable<Product> entities)
    {
        _context.Products.AddRange(entities);
        await _context.SaveChangesAsync();
        return entities;
    }

    public async Task<IEnumerable<Product>> RemoveRange(IEnumerable<Product> entities)
    {
        _context.Products.RemoveRange(entities);
        await _context.SaveChangesAsync();
        return entities;
    }

    public async Task<IEnumerable<Product>> UpdateRange(IEnumerable<Product> entities)
    {
        _context.Products.UpdateRange(entities);
        await _context.SaveChangesAsync();
        return entities;
    }
}