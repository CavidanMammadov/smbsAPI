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
    public class RefreshTokenRepository : Repository<RefreshToken>, IRefreshTokenRepository
    {
        private readonly AppDbContext _appDbContext;
        public RefreshTokenRepository(AppDbContext context) : base(context)
        {
            _appDbContext = context;
        }

        public async Task<RefreshToken> GetRefreshTokenByToken(string token)
        {
            var refreshToken =await _appDbContext.RefreshTokens.FirstOrDefaultAsync(a => a.RefreshTokenToken == token);
            return refreshToken!;
        }
    }
}
