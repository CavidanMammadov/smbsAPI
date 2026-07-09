using Smbs.Domain.Entities;
using Smbs.Domain.Interfaces;
using Smbs.Persistence.Context;

namespace Smbs.Persistence.Repositories;

public class LandingPageRepository : Repository<LandingPage>, ILandingPageRepository
{
    public LandingPageRepository(AppDbContext context) : base(context)
    {
    }
}
