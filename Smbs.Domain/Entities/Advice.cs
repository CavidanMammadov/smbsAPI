using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Domain.Entities
{
    public class Advice
    {
        public int AdviceId { get; set; }
        public string AdviceTitle { get; set; }
        public  string AdviceImage { get; set; }
        public string AdviceDescription { get; set; }
        public string AdviceContent { get; set; }
        public DateTime AdviceCreated { get; set; } = DateTime.Now;
        public string AdviceDuration { get; set; }
        public List<AdviceTitle> AdviceTitles { get; set; }
    }
}
