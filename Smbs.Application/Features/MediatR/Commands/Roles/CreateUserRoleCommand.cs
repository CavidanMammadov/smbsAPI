using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Results.Roles;
using Smbs.Domain;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Commands.Roles
{
    public class CreateUserRoleCommand:IRequest<IResult<DomainSuccess<UserRoleResult>,DomainError>>
    {
        public string UserRoleName { get; set; }
    }
}
