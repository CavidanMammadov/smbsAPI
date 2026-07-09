using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Queries.RefreshTokens;
using Smbs.Application.Features.MediatR.Results.RefreshTokens;
using Smbs.Domain;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Handlers.RefreshTokens
{
    public class GetRefreshTokenByTokenQueryHandler(IRefreshTokenRepository repository) : IRequestHandler<GetRefreshTokenByTokenQuery, IResult<DomainSuccess<RefreshTokenResult>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<RefreshTokenResult>, DomainError>> Handle(GetRefreshTokenByTokenQuery request, CancellationToken cancellationToken)
        {
            var refreshToken =await repository.GetRefreshTokenByToken(request.Token);
            if (refreshToken == null)
            {
                return Result.Fail<RefreshTokenResult>(DomainError.NotFound("Refresh token not found."));
            }
            return Result.Success<RefreshTokenResult>(DomainSuccess<RefreshTokenResult>.OK(new RefreshTokenResult
            {
                RefreshTokenId = refreshToken.RefreshTokenId,
                RefreshTokenExpireIn = refreshToken.RefreshTokenExpireIn,
                RefreshTokenToken = refreshToken.RefreshTokenToken,
                RefreshTokenUserId = refreshToken.RefreshTokenUserId
            }));
        }
    }
}
