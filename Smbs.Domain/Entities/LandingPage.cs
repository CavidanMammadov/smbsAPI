using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Domain.Entities
{
    public class LandingPage
    {
        public int LandingPageId { get; set; }
        public string LandingPageTitle { get; set; }
        public string LandingPageImage { get; set; }
        public string LandingPageDescription { get; set; }
        public string LandingPageButton { get; set; }
    }
}
