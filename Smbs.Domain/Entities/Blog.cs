using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Domain.Entities
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string BlogTitle { get; set; }
        public string BlogDescription { get; set; }
        public string BlogImage { get; set; }
        public string BlogResult { get; set; }
        public List<BlogModule> BlogModules { get; set; }
    }
}
