using Smbs.Domain.Enums;

namespace Smbs.Application.Features.MediatR.Results.Applyments
{
    public class GetApplymentByIdResult
    {
        public int ApplymentId { get; set; }
        public string ApplymentNameAndSurname { get; set; }
        public string ApplymentPhoneNumber { get; set; }
        public TrainingType ApplymentType { get; set; }
        public string ApplymentEmail { get; set; }
        public string ApplymentTrainingName { get; set; }

    }
}
