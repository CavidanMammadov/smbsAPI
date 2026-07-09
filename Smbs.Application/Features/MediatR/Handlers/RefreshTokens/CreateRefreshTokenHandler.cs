using MediatR;
using Smbs.Application.Features.MediatR.Commands.RefreshTokens;
using Smbs.Application.Features.MediatR.Results.RefreshTokens;
using Smbs.Domain;
using Smbs.Domain.Entities;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Handlers.RefreshTokens
{
    public class CreateRefreshTokenHandler(IRepository<RefreshToken> repository) : IRequestHandler<CreateRefreshTokenCommand, IResult<DomainSuccess<RefreshTokenResult>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<RefreshTokenResult>, DomainError>> Handle(CreateRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var token = new RefreshToken
            {
                RefreshTokenToken = request.RefreshTokenToken,
                RefreshTokenUserId = request.RefreshTokenUserId,
                RefreshTokenExpireIn = request.RefreshTokenExpireIn
            };
            await repository.Create(token);
            return Result.Success<RefreshTokenResult>(DomainSuccess<RefreshTokenResult>.OK(new RefreshTokenResult()
            {
                RefreshTokenId = token.RefreshTokenId,
                RefreshTokenExpireIn = request.RefreshTokenExpireIn,
                RefreshTokenToken = request.RefreshTokenToken,
                RefreshTokenUserId = request.RefreshTokenUserId

            }));
        }
    }
}
