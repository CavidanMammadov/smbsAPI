using Microsoft.EntityFrameworkCore;
using Smbs.Domain.Entities;
using Smbs.Domain.Interfaces;
using Smbs.Persistence.Context;

namespace Smbs.Persistence.Repositories;

public class BlogRepository : Repository<Blog>, IBlogRepository
{
    private readonly AppDbContext _context;
    public BlogRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<List<Blog>> GetAllWithModulesAsync()
    {
        return await _context.Blogs
            .Include(x => x.BlogModules)
            .ToListAsync();
    }

    public Task<Blog> GetByIdWithModulesAsync(int id)
    {
        return _context.Blogs
            .Include(x => x.BlogModules)
            .FirstOrDefaultAsync(x => x.BlogId == id);
    }
}
