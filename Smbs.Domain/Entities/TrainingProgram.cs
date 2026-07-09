using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Domain.Entities
{
    public class TrainingProgram
    {
        public int TrainingProgramId { get; set; }
        public string TrainingProgramTitle { get; set; }
        public string TrainingProgramDescription { get; set; }
        public int TrainingProgramTrainerId { get; set; }
        public Trainer TrainingProgramTrainer { get; set; }
    }
}
