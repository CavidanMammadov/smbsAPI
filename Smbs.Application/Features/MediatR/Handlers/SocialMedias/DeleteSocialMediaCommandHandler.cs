using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Commands.SocialMedias;
using Smbs.Domain;
using Smbs.Domain.Entities;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Handlers.SocialMedias
{
    public class DeleteSocialMediaCommandHandler(IRepository<SocialMedia> repository) : IRequestHandler<DeleteSocialMediaCommand, IResult<DomainSuccess<int>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<int>, DomainError>> Handle(DeleteSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var result = await repository.GetById(request.Id);
            if (result == null)
            {
                return Result.Fail<int>(DomainError.NotFound("Social media not found."));
            }
            else
            {
                await repository.Delete(result);
                return Result.Success(DomainSuccess<int>.OK(request.Id));
            }
        }
    }
}
