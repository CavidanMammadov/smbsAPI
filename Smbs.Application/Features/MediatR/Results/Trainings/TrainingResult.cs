using Smbs.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Results.Trainings
{
    public class TrainingResult
    {
        public int TrainingId { get; set; }
        public string TrainingTitle { get; set; }
        public string TrainingDescription { get; set; }
        public string TrainingDuration { get; set; }
        public string TrainingGroupSize { get; set; }
        public string TrainingLanguage { get; set; }
        public string TrainingImage { get; set; }
        public string TrainingAbout { get; set; }
        public string TrainingCoveredTopics { get; set; }
        public string TrainingSchedule { get; set; }
        public string TrainingAddress { get; set; }
        public string TrainingWorkOpportunity { get; set; }
        public string TrainingFormat { get; set; }
        public int TrainingPrice { get; set; }
        public string TrainingTeacher { get; set; }
        public string TrainingTeacherCertificate { get; set; }
        public int TrainingAudienceType { get; set; }
    }
}
