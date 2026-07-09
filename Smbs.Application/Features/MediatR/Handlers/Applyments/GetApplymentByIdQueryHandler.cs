using MediatR;
using Smbs.Application.Features.MediatR.Queries.Applyments;
using Smbs.Application.Features.MediatR.Results.Applyments;
using Smbs.Domain;
using Smbs.Domain.Entities;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;
using System.Threading;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Handlers.Applyments
{
    public class GetApplymentByIdQueryHandler : IRequestHandler<GetApplymentByIdQuery, IResult<DomainSuccess<GetApplymentByIdResult>, DomainError>>
    {
        private readonly IRepository<Applyment> _repository;

        public GetApplymentByIdQueryHandler(IRepository<Applyment> repository)
        {
            _repository = repository;
        }

        public async Task<IResult<DomainSuccess<GetApplymentByIdResult>, DomainError>> Handle(GetApplymentByIdQuery request, CancellationToken cancellationToken)
        {
            var applyment = await _repository.GetById(request.Id);
            if (applyment == null)
            {
                return Result.Fail<GetApplymentByIdResult>(DomainError.NotFound($"Applyment with ID {request.Id} not found."));
            }

            var result = new GetApplymentByIdResult
            {
                ApplymentId = applyment.ApplymentId,
                ApplymentNameAndSurname = applyment.ApplymentNameAndSurname,
                ApplymentPhoneNumber = applyment.ApplymentPhoneNumber,
                ApplymentEmail = applyment.ApplymentEmail,
                ApplymentTrainingName = applyment.ApplymentTrainingName,
                ApplymentType = applyment.ApplymentType

            };

            return Result.Success(DomainSuccess<GetApplymentByIdResult>.OK(result, "Applyment retrieved successfully."));
                    }
    }
}
    