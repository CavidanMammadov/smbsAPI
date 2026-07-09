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

namespace Smbs.Application.Features.MediatR.Commands.RefreshTokens
{
    public class CreateRefreshTokenCommand:IRequest<IResult<DomainSuccess<RefreshTokenResult>,DomainError>>
    {
        public string RefreshTokenToken { get; set; }
        public DateTime RefreshTokenExpireIn { get; set; }
        public int RefreshTokenUserId { get; set; }
    }
}
