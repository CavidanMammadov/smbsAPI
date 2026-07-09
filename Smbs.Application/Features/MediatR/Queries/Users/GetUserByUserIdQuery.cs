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

namespace Smbs.Application.Features.MediatR.Queries.Users
{
    public class GetUserByUserIdQuery:IRequest<IResult<DomainSuccess<UserResult>,DomainError>>
    {
        public int UserId { get; set; }

        public GetUserByUserIdQuery(int userId)
        {
            UserId = userId;
        }
    }
}
