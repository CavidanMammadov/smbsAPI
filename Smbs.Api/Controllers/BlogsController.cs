using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Smbs.Application.Features.MediatR.Queries.Blogs;
using Smbs.Application.Features.MediatR.Results.Blogs;
using Smbs.Domain;
using Smbs.Domain.Results;

namespace Smbs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class BlogsController(IMediator mediator) : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        [EnableRateLimiting("anon-limit")]
        [ProducesResponseType(typeof(IResult<DomainSuccess<List<Smbs.Application.Features.MediatR.Results.Blogs.ResultBlogDto>>, DomainError>), 200)]
        public async Task<IActionResult> GetAll()
        {
            var value = await mediator.Send(new Smbs.Application.Features.MediatR.Queries.Blogs.GetAllBlogsQuery());
            return Ok(value);
        }

        [HttpGet("pagination")]
        [AllowAnonymous]
        [EnableRateLimiting("anon-limit")]
        [ProducesResponseType(typeof(IResult<DomainSuccess<PaginatedResult<ResultBlogDto>>, DomainError>), 200)]
        public async Task<IActionResult> GetAllPagination([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var query = new GetBlogsWithPaginationQuery(pageNumber, pageSize);
            var value = await mediator.Send(query);
            return Ok(value);
        }

        [HttpGet("{id}")]
        [AllowAnonymous]
        [EnableRateLimiting("anon-limit")]
        [ProducesResponseType(typeof(IResult<DomainSuccess<Smbs.Application.Features.MediatR.Results.Blogs.ResultBlogDto>, DomainError>), 200)]
        public async Task<IActionResult> GetById(int id)
        {
            var value = await mediator.Send(new Smbs.Application.Features.MediatR.Queries.Blogs.GetByIdBlogQuery { Id = id });
            return Ok(value);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        [ProducesResponseType(typeof(IResult<DomainSuccess<Smbs.Application.Features.MediatR.Results.Blogs.ResultBlogDto>, DomainError>), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        public async Task<IActionResult> Create([FromForm]Smbs.Application.Features.MediatR.Commands.Blogs.CreateBlogCommand command)
        {
            var value = await mediator.Send(command);
            return Ok(value);
        }

        [HttpPut]
        [Consumes("multipart/form-data")]
        [ProducesResponseType(typeof(IResult<DomainSuccess<Smbs.Application.Features.MediatR.Results.Blogs.ResultBlogDto>, DomainError>), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        public async Task<IActionResult> Update([FromForm]Smbs.Application.Features.MediatR.Commands.Blogs.UpdateBlogCommand command)
        {
            var value = await mediator.Send(command);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(IResult<DomainSuccess<int>, DomainError>), 200)]
        public async Task<IActionResult> Delete(int id)
        {
            var value = await mediator.Send(new Smbs.Application.Features.MediatR.Commands.Blogs.DeleteBlogCommand { Id = id });
            return Ok(value);
        }
    }
}