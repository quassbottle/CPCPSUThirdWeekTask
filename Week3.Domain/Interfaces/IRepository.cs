using System.Linq.Expressions;
using Week3.Domain.Entities;

namespace Week3.Domain.Interfaces;

public interface IRepository<T> where T : class
{
    Task<T> GetById(int id);
    Task<IEnumerable<T>> GetAll();
    Task<IEnumerable<T>> Find(Expression<Func<Product, bool>> exp);
    Task<T> Add(T entity);
    Task<T> Update(T entity);
    Task<T> Remove(T entity);
    Task<IEnumerable<T>> AddRange(IEnumerable<T> entities);
    Task<IEnumerable<T>> RemoveRange(IEnumerable<T> entities);
    Task<IEnumerable<T>> UpdateRange(IEnumerable<T> entities);
}