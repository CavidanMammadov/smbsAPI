using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Results.SocialMedias
{
    public class SocialMediaResult
    {
        public int SocialMediaId { get; set; }
        public string SocialMediaName { get; set; }
        public string SocialMediaIcon { get; set; }
        public string SocialMediaUrl { get; set; }
        public string SocialMediaImage { get; set; }
    }
}
