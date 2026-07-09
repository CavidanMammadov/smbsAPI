using Smbs.Domain.Entities;
using Smbs.Domain.Interfaces;
using Smbs.Persistence.Context;

namespace Smbs.Persistence.Repositories
{
    public class SocialMediaRepository:Repository<SocialMedia>, ISocialMediaRepository
    {
        private readonly AppDbContext _context;
        public SocialMediaRepository(AppDbContext context):base (context) 
        {
            _context = context;
        }
    }
}
