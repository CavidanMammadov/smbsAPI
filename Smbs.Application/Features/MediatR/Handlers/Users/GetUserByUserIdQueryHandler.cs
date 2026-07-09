using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Queries.Users;
using Smbs.Application.Features.MediatR.Results.Users;
using Smbs.Domain;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Handlers.Users
{
    public class GetUserByUserIdQueryHandler(IUserRepository repository) : IRequestHandler<GetUserByUserIdQuery, IResult<DomainSuccess<UserResult>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<UserResult>, DomainError>> Handle(GetUserByUserIdQuery request, CancellationToken cancellationToken)
        {
            var user =await repository.GetUserByUserId(request.UserId);
            if (user == null)
            {
                return Result.Fail<UserResult>(DomainError.NotFound("User not found."));
            }
            return Result.Success<UserResult>(DomainSuccess<UserResult>.OK(new UserResult
            {
                UserId = user.UserId,
                UserImage = user.UserImage,
                UserEmail = user.UserEmail,
                UserFirstName = user.UserFirstName,
                UserLastName = user.UserLastName,
                UserPasswordHash = user.UserPasswordHash,
                UserRoleId = user.UserRoleId,
                UserUserName = user.UserUserName,
            }));
        }
    }
}
