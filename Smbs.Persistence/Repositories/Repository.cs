using Microsoft.EntityFrameworkCore;
using Smbs.Domain.Interfaces;
using Smbs.Persistence.Context;
using System.Linq.Expressions;

namespace Smbs.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext _context;

        public Repository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public IQueryable<T> GetAsQueryable()
        {
            return _context.Set<T>().AsNoTracking();
        }

        public async Task<T> GetById(int id)
        {
            var item = await _context.Set<T>().FindAsync(id);
            return item!;
        }

        public async Task Update(T entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<T>> Where(Expression<Func<T, bool>> predicate)
        {var items =await _context.Set<T>().Where(predicate).ToListAsync();
            return items;
        }
    }
}
