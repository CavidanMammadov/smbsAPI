using MediatR;
using Smbs.Application.Features.MediatR.Results.Applyments;
using Smbs.Domain;
using Smbs.Domain.Enums;
using Smbs.Domain.Results;

namespace Smbs.Application.Features.MediatR.Commands.Applyments
{
    public class CreateApplymentCommand : IRequest<IResult<DomainSuccess<CreateApplymentResult>, DomainError>>
    {
        public string NameAndSurname { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string TrainingName { get; set; }
        public TrainingType Type { get; set; }

    }
}
