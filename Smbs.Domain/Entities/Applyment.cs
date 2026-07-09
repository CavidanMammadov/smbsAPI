using Smbs.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Domain.Entities
{
    public class Applyment
    {
        public int ApplymentId { get; set; }
        public string ApplymentNameAndSurname { get; set; }
        public string ApplymentPhoneNumber { get; set; }
        public TrainingType ApplymentType { get; set; }
        public string ApplymentEmail { get; set; }
        public string ApplymentTrainingName { get; set; }
    }
}
