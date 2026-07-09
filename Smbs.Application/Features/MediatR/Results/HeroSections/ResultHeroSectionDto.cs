using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Results.HeroSections
{
    public class ResultHeroSectionDto
    {
        public int HeroSectionId { get; set; }
        public string HeroSectionTitle { get; set; }
        public string HeroSectionDescription { get; set; }
    }
}
