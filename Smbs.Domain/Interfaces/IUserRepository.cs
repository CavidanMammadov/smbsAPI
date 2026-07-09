using Smbs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByUserName(string userName);
        Task<User> GetUserByUserId(int id);
    }
}
