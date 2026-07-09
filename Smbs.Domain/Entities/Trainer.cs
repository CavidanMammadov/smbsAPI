using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Domain.Entities
{
    public class Trainer
    {
        public int TrainerId { get; set; }
        public string TrainerNameAndSurname { get; set; }
        public string TrainerPosition { get; set; }
        public string TrainerDescription { get; set; }
        public string TrainerImgUrl { get; set; }
        public string? TrainerTrainingVideoUrl { get; set; }
        public List<TrainingProgram> TrainerTrainingPrograms { get; set; }
        public List<Student> TrainerStudents { get; set; }
    }
}
