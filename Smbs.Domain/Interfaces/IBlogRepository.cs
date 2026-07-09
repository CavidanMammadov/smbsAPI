using Smbs.Domain.Entities;

namespace Smbs.Domain.Interfaces;

public interface IBlogRepository : IRepository<Blog>
{
    Task<List<Blog>> GetAllWithModulesAsync();
    Task<Blog> GetByIdWithModulesAsync(int id);
}

