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
    public class UpdateApplymentCommandHandler(IRepository<Applyment> repository) : IRequestHandler<UpdateApplymentCommand, IResult<DomainSuccess<UpdateApplymentResult>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<UpdateApplymentResult>, DomainError>> Handle(UpdateApplymentCommand request, CancellationToken cancellationToken)
        {
            var applyment=await repository.GetById(request.Id);
            if(applyment == null)
            {
                return Result.Fail<UpdateApplymentResult>(DomainError.NotFound("Applyment not found"));
            }
            applyment.ApplymentPhoneNumber = request.PhoneNumber;
            applyment.ApplymentEmail = request.Email;
            applyment.ApplymentNameAndSurname = request.NameAndSurname;
            applyment.ApplymentTrainingName = request.TrainingName;
            await repository.Update(applyment);
            return Result.Success(DomainSuccess<UpdateApplymentResult>.OK(new UpdateApplymentResult
            {
                ApplymentId = applyment.ApplymentId,
                ApplymentType = applyment.ApplymentType,
                ApplymentNameAndSurname = request.NameAndSurname,
                ApplymentPhoneNumber = request.PhoneNumber,
                ApplymentEmail = request.Email,
                ApplymentTrainingName = request.TrainingName
            }, "Updated successfully"));
        }
    }
}
