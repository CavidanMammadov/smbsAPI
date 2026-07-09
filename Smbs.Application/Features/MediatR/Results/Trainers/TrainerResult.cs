using Smbs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Results.Trainers
{
    public class TrainerResult
    {
        public int TrainerId { get; set; }
        public string TrainerNameAndSurname { get; set; }
        public string TrainerPosition { get; set; }
        public string TrainerDescription { get; set; }
        public string TrainerImgUrl { get; set; }
        public string TrainerTrainingVideoUrl { get; set; }
        public List<TrainingProgram> TrainerTrainingPrograms { get; set; }
    }
}
