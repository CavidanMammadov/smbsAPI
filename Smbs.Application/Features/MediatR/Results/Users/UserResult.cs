using Smbs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Results.Users
{
    public class UserResult
    {
        
        public int UserId { get; set; }
        public string UserUserName { get; set; }
        public string UserFirstName { get; set; }
        public string? UserImage { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }
        public string UserPasswordHash { get; set; }
        public int UserRoleId { get; set; }
    }
}
