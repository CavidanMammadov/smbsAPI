using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Results.Students
{
    public class StudentResult
    {
        public int StudentId { get; set; }
        public string StudentNameAndSurname { get; set; }
        public int? TrainerId { get; set; }
        public string? StudentScore { get; set; }
        public string StudentCertificateNumber { get; set; }
        public string StudentCertificateType { get; set; }
        public string StudentCertificateTraining { get; set; }
        public string StudentTrainingTime { get; set; }
        public string StudentCertificateGivingTime { get; set; }
        public DateTime StudentCreatedAt { get; set; }
    }
}
