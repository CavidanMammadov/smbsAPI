using MediatR;
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
    public class GetUserByUserNameQuery:IRequest<IResult<DomainSuccess<UserResult>, DomainError>>
    {
        public string UserName { get; set; }

        public GetUserByUserNameQuery(string userName)
        {
            UserName = userName;
        }
    }
}
