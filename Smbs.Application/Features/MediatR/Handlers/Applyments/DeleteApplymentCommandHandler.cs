using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Commands.Applyments;
using Smbs.Application.Features.MediatR.Results.Applyments;
using Smbs.Domain;
using Smbs.Domain.Entities;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;

namespace Smbs.Application.Features.MediatR.Handlers.Applyments
{
    public class DeleteApplymentCommandHandler(IRepository<Applyment> repository) : IRequestHandler<DeleteApplymentCommand, IResult<DomainSuccess<int>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<int>, DomainError>> Handle(DeleteApplymentCommand request, CancellationToken cancellationToken)
        {
            var result =await repository.GetById(request.Id);
            if(result is null)
            {
                return Result.Fail<int>(DomainError.NotFound("Canr be found in this id"));
            }
           await repository.Delete(result);
            return Result.Success<int>(DomainSuccess<int>.OK(request.Id));
        }
    }
}
