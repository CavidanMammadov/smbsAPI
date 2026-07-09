using Microsoft.EntityFrameworkCore;
using Smbs.Domain.Entities;
using Smbs.Domain.Interfaces;
using Smbs.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Persistence.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetByUserName(string userName)
        {
            var user = await _context.Users.FirstOrDefaultAsync(a => a.UserUserName == userName);
            return user!;
        }

        public async Task<User> GetUserByUserId(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(a => a.UserId == id);
            return user!;
        }
    }
}
