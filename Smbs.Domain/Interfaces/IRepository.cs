using System.Linq.Expressions;

namespace Smbs.Domain.Interfaces
{
    public interface IRepository<T> where T:class
    {
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<List<T>> GetAll();
        Task<T> GetById(int id);
        Task<List<T>> Where(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAsQueryable();
    }
}
