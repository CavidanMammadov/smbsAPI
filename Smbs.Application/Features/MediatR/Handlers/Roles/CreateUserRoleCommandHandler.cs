using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Commands.Roles;
using Smbs.Application.Features.MediatR.Results.Roles;
using Smbs.Domain;
using Smbs.Domain.Entities;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Handlers.Roles
{
    public class CreateUserRoleCommandHandler(IRepository<UserRole> repository) : IRequestHandler<CreateUserRoleCommand, IResult<DomainSuccess<UserRoleResult>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<UserRoleResult>, DomainError>> Handle(CreateUserRoleCommand request, CancellationToken cancellationToken)
        {
            var role = new UserRole
            {
                UserRoleName = request.UserRoleName
            };
            await repository.Create(role);
            return Result.Success<UserRoleResult>(DomainSuccess<UserRoleResult>.OK(new UserRoleResult
            {UserRoleId=role.UserRoleId,
                UserRoleName = request.UserRoleName
            }));
        }
    }
}
