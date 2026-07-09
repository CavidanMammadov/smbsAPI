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
    public class UpdateAdviceTitleCommandHandler(IRepository<AdviceTitle> repository) : IRequestHandler<UpdateAdviceTitleCommand, IResult<DomainSuccess<AdviceTitleResult>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<AdviceTitleResult>, DomainError>> Handle(UpdateAdviceTitleCommand request, CancellationToken cancellationToken)
        {
            var result=await repository.GetById(request.AdviceTitleId);
            if(result==null)
                return Result.Fail<AdviceTitleResult>(DomainError.NotFound("Advice title not found"));
            result.AdviceTitleContent = request.AdviceTitleContent;
            result.AdviceTitleAdviceId = request.AdviceTitleAdviceId;
            await repository.Update(result);
            return Result.Success<AdviceTitleResult>(DomainSuccess<AdviceTitleResult>.OK(new AdviceTitleResult
            {
                AdviceTitleId = request.AdviceTitleId,
                AdviceTitleContent = request.AdviceTitleContent,
                AdviceTitleAdviceId = request.AdviceTitleAdviceId
            }));
        }
    }
}
