using Smbs.Domain.Entities;
using Smbs.Domain.Interfaces;
using Smbs.Persistence.Context;

namespace Smbs.Persistence.Repositories;

public class AboutUsRepository : Repository<AboutUs>, IAboutUsRepository
{
    public AboutUsRepository(AppDbContext context) : base(context)
    {
    }
}
