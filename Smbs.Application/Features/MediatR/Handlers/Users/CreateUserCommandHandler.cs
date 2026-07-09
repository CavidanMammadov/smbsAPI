using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Smbs.Application.Features.MediatR.Commands.Users;
using Smbs.Application.Features.MediatR.Results.Users;
using Smbs.Domain;
using Smbs.Domain.Entities;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Handlers.Users
{
    public class CreateUserCommandHandler(IRepository<User> repository, IPasswordHasher<User> hasher) : IRequestHandler<CreateUserCommand, IResult<DomainSuccess<UserResult>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<UserResult>, DomainError>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userByUserName = await repository.Where(u => u.UserUserName == request.UserUserName);
            if (userByUserName != null && userByUserName.Any())
            {
                return Result.Fail<UserResult>(DomainError.BadRequest("This userName already exist"));
            }
            else
            {
                var user = new User
                {
                    UserUserName = request.UserUserName,
                    UserRoleId = request.UserRoleId,
                    UserLastName = request.UserLastName,
                    UserFirstName = request.UserFirstName,
                    UserEmail = request.UserEmail,
                };
                user.UserPasswordHash = hasher.HashPassword(user, request.UserPassword);
                await repository.Create(user);
                return Result.Success(DomainSuccess<UserResult>.OK(new UserResult
                {
                    UserId = user.UserId,
                    UserUserName = request.UserUserName,
                    UserRoleId = request.UserRoleId,
                    UserLastName = request.UserLastName,
                    UserFirstName = request.UserFirstName,
                    UserEmail = request.UserEmail,
                    UserPasswordHash = user.UserPasswordHash
                }));

            }
               
        }
    }
}
