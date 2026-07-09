using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Domain.Entities
{
    public class AdviceSubtitle
    {
        public int AdviceSubtitleId { get; set; }
        public string AdviceSubtitleContent { get; set; }
        public int AdviceSubtitleAdviceTitleId { get; set; }
        public AdviceTitle AdviceSubtitleAdviceTitle { get; set; }
    }
}
