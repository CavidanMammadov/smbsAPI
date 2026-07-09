using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Domain.Entities
{
    public class BlogModule
    {
        public int BlogModuleId { get; set; }
        public string BlogModuleContent { get; set; }
        public int BlogModuleBlogId { get; set; }
        public Blog BlogModuleBlog { get; set; }
    }
}
