using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Results.Advice
{
    public class CreateAdviceResult
    {
        public int AdviceId { get; set; }
        public string AdviceTitle { get; set; }
        public string AdviceImage { get; set; }
        public string AdviceDescription { get; set; }
        public string AdviceContent { get; set; }
        public string AdviceDuration { get; set; }
    }
}
