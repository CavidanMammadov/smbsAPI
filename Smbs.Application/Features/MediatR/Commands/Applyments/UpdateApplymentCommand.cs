using MediatR;
using Smbs.Application.Features.MediatR.Results.Applyments;
using Smbs.Domain.Results;
using Smbs.Domain;

namespace Smbs.Application.Features.MediatR.Commands.Applyments
{
    public class UpdateApplymentCommand : IRequest<IResult<DomainSuccess<UpdateApplymentResult>, DomainError>>
    {
        public int Id { get; set; }
        public string NameAndSurname { get; set; }
        public string PhoneNumber { get; set; }
        public int Type { get; set; }
        public string Email { get; set; }
        public string TrainingName { get; set; }
    }
}
