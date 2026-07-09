using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Results.Users;
using Smbs.Domain;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Commands.Users
{
    public class CreateUserCommand:IRequest<IResult<DomainSuccess<UserResult>,DomainError>>
    {
        public string UserUserName { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public int UserRoleId { get; set; }
    }
}
