using MediatR;
using Smbs.Application.Features.MediatR.Results.BlogModules;
using Smbs.Domain;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Queries.BlogModules
{
    public class GetBlogModulesByBlogIdQuery:IRequest<IResult<DomainSuccess<List<BlogModuleResult>>, DomainError>>
    {
        public int BlogId { get; set; }

        public GetBlogModulesByBlogIdQuery(int blogId)
        {
            BlogId = blogId;
        }
    }
}
