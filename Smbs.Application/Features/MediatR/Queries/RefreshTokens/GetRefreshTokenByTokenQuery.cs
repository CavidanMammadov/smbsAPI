using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Results.RefreshTokens;
using Smbs.Domain;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Queries.RefreshTokens
{
    public class GetRefreshTokenByTokenQuery:IRequest<IResult<DomainSuccess<RefreshTokenResult>,DomainError>>
    {
        public string Token { get; set; }

        public GetRefreshTokenByTokenQuery(string token)
        {
            Token = token;
        }
    }
}
