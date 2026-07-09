using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Results.Blogs;
using Smbs.Domain;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Queries.Blogs
{
    public class GetAllBlogsQuery:IRequest<IResult<DomainSuccess<List<ResultBlogDto>>,DomainError>>
    {
    }
}
