using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Domain.Entities
{
    public class AdviceTitle
    {
        public int AdviceTitleId { get; set; }
        public string AdviceTitleContent { get; set; }
        public int AdviceTitleAdviceId { get; set; }
        public Advice AdviceTitleAdvice { get; set; }
        public List<AdviceSubtitle> AdviceTitleAdviceSubtitles { get; set; }
    }
}
