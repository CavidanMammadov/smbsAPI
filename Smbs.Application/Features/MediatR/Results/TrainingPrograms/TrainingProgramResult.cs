using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Results.TrainingPrograms
{
    public class TrainingProgramResult
    {
        public int TrainingProgramId { get; set; }
        public string TrainingProgramTitle { get; set; }
        public string TrainingProgramDescription { get; set; }
        public int TrainingProgramTrainerId { get; set; }
    }
}
