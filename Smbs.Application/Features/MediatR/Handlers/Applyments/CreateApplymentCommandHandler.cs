using MediatR;
using Smbs.Application.Features.MediatR.Commands.Applyments;
using Smbs.Application.Features.MediatR.Results.Applyments;
using Smbs.Domain;
using Smbs.Domain.Entities;
using Smbs.Domain.Enums;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;

namespace Smbs.Application.Features.MediatR.Handlers.Applyments
{
    public class CreateApplymentCommandHandler : IRequestHandler<CreateApplymentCommand, IResult<DomainSuccess<CreateApplymentResult>, DomainError>>
    {
        private readonly IRepository<Applyment> _repository;

        public CreateApplymentCommandHandler(IRepository<Applyment> repository)
        {
            _repository = repository;
        }

        public async Task<IResult<DomainSuccess<CreateApplymentResult>, DomainError>> Handle(CreateApplymentCommand request, CancellationToken cancellationToken)
        {
            var applyment = new Applyment
            {
               
                ApplymentNameAndSurname = request.NameAndSurname,
                ApplymentPhoneNumber = request.PhoneNumber,
                ApplymentType = (TrainingType)request.Type,
                ApplymentEmail = request.Email,
                ApplymentTrainingName = request.TrainingName
            };

            await _repository.Create(applyment);
            return Result.Success(DomainSuccess<CreateApplymentResult>.Created( new CreateApplymentResult { ApplymentId = applyment.ApplymentId ,ApplymentEmail=applyment.ApplymentEmail,ApplymentNameAndSurname=applyment.ApplymentNameAndSurname,ApplymentPhoneNumber=applyment.ApplymentPhoneNumber,ApplymentTrainingName=applyment.ApplymentTrainingName,ApplymentType=applyment.ApplymentType},"Created"));
        }
    }
}