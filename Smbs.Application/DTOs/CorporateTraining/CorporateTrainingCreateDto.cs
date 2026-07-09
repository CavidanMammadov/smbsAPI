using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.DTOs.CorporateTraining
{
    public class CorporateTrainingCreateDto
    {

        public string CorporateTrainingCompanyName { get; set; }

        public string CorporateTrainingPosition { get; set; }

        public string CorporateTrainingDirection { get; set; }

        public string CorporateTrainingSchedule { get; set; }

        public string CorporateTrainingContactInfo { get; set; }

        public int CorporateTrainingEmployeeCount { get; set; }

        public DateTime CorporateTrainingContractDate { get; set; }
    }
}
