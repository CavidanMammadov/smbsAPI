using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Results.Certificates
{
    public class CreateCertificateResult
    {
      
        public int CertificateUserId { get; set; }
        public string CertificateNumber { get; set; }
        public string TypeOfCertificate { get; set; }
        public string Training { get; set; }
        public string TrainingDate { get; set; }
        public string GivingTime { get; set; }
    }
}
