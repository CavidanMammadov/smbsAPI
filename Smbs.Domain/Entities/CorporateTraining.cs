using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Domain.Entities
{
    public  class CorporateTraining
    {
        public int CorporateTrainingId { get; set; }
        public string CorporateTrainingCompanyName  { get; set; }
        public string CorporateTrainingPosition { get; set; }
        public string CorporateTrainingDirection { get; set; }
        public string CorporateTrainingSchedule { get; set; }
        public string CorporateTrainingContactInfo { get; set; }
        public int CorporateTrainingEmployeeCount { get; set; }
        public DateTime CorporateTrainingContractDate { get; set; }
        public DateTime CorporateTrainingCreatedAt { get; set; } = DateTime.Now;
        public bool CorporateTrainingIsActive { get; set; } = true;



    }
}
