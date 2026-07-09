using MediatR;
using Smbs.Application.Features.MediatR.Commands.AdviceTitles;
using Smbs.Application.Features.MediatR.Results.AdviceTitles;
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
    public class CreateAdviceTitleCommandHandler(IRepository<AdviceTitle> repository) : IRequestHandler<CreateAdviceTitleCommand, IResult<DomainSuccess<AdviceTitleResult>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<AdviceTitleResult>, DomainError>> Handle(CreateAdviceTitleCommand request, CancellationToken cancellationToken)
        {
            var result=new AdviceTitle
            {
                AdviceTitleContent = request.AdviceTitleContent,
                AdviceTitleAdviceId = request.AdviceTitleAdviceId
            };
            await repository.Create(result);
            return Result.Success<AdviceTitleResult>(DomainSuccess<AdviceTitleResult>.Created(new AdviceTitleResult
            {
                AdviceTitleId = result.AdviceTitleId,
                AdviceTitleContent = result.AdviceTitleContent,
                AdviceTitleAdviceId = result.AdviceTitleAdviceId
            }));
        }
    }
}
