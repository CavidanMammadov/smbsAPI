using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Results.BlogModules
{
    public class BlogModuleResult
    {
        public int BlogModuleId { get; set; }
        public string BlogModuleContent { get; set; }
        public int BlogModuleBlogId { get; set; }
    }
}
