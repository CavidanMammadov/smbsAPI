using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Results.AdviceTitles
{
    public class AdviceTitleResult
    {
        public int AdviceTitleId { get; set; }
        public string AdviceTitleContent { get; set; }
        public int AdviceTitleAdviceId { get; set; }
    }
}
