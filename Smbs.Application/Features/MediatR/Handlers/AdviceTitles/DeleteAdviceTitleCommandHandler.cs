using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Commands.AdviceTitles;
using Smbs.Domain;
using Smbs.Domain.Entities;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Handlers.AdviceTitles
{
    public class DeleteAdviceTitleCommandHandler(IRepository<AdviceTitle> repository) : IRequestHandler<DeleteAdviceTitleCommand, IResult<DomainSuccess<int>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<int>, DomainError>> Handle(DeleteAdviceTitleCommand request, CancellationToken cancellationToken)
        {
            var result = await repository.GetById(request.Id);
            if (result == null)
            {
                return Result.Fail<int>(DomainError.NotFound("Advice title not found"));
            }
            else
            {
                await repository.Delete(result);
                return Result.Success<int>(DomainSuccess<int>.OK(request.Id));
            }
        }
    }
}
