using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Results.AdviceSubtitles
{
    public class AdviceSubtitleResult
    {
        public int AdviceSubtitleId { get; set; }
        public string AdviceSubtitleContent { get; set; }
        public int AdviceSubtitleAdviceTitleId { get; set; }
    }
}
