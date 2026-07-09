using Smbs.Domain.Entities;
using Smbs.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Domain.Interfaces
{
    public interface IRefreshTokenRepository:IRepository<RefreshToken>
    {
        Task<RefreshToken> GetRefreshTokenByToken(string token);
    }
}
