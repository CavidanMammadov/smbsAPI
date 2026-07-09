using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Results.Policies
{
    public class PolicyResult
    {
        public int PolicyId { get; set; }
        public string PolicyTitle { get; set; }
        public string PolicyContent { get; set; }
        
    }
}
