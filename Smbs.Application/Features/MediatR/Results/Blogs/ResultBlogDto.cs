using Smbs.Domain.Entities;

namespace Smbs.Application.Features.MediatR.Results.Blogs
{
    public class ResultBlogDto
    {
        public int BlogId { get; set; }
        public string BlogTitle { get; set; }
        public string BlogDescription { get; set; }
        public string Result { get; set; }
        public string BlogImage { get; set; }
        public List<BlogModule> BlogModules { get; set; }
    }
}
