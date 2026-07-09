using MediatR;
using Smbs.Application.Features.MediatR.Queries.Users;
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
    public class GetUserByUserNameQueryHandler(IUserRepository repository) : IRequestHandler<GetUserByUserNameQuery, IResult<DomainSuccess<UserResult>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<UserResult>, DomainError>> Handle(GetUserByUserNameQuery request, CancellationToken cancellationToken)
        {
            var user = await repository.GetByUserName(request.UserName);
            if (user == null)
            {
                return Result.Fail<UserResult>(DomainError.NotFound("Cant be found"));
            }
            return Result.Success<UserResult>(DomainSuccess<UserResult>.OK(new UserResult
            {
                UserId=user.UserId,
                UserImage= user.UserImage,
                UserEmail = user.UserEmail,
                UserFirstName = user.UserFirstName,
                UserLastName = user.UserLastName,
                UserUserName = user.UserUserName,
                UserRoleId = user.UserRoleId,
                UserPasswordHash = user.UserPasswordHash
            }, "Found successfully"));
        }
    }
}
