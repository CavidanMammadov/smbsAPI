using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Smbs.Application.Features.MediatR.Commands.BlogModules;
using Smbs.Application.Features.MediatR.Queries.BlogModules;
using Smbs.Application.Features.MediatR.Results.AboutUs;
using Smbs.Domain.Results;
using Smbs.Domain;
using Smbs.Application.Features.MediatR.Results.BlogModules;
using Microsoft.AspNetCore.RateLimiting;

namespace Smbs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class BlogModulesController(IMediator mediator) : ControllerBase
    {
        [HttpGet("GetAll")]
        [ProducesResponseType(typeof(IResult<DomainSuccess<List<BlogModuleResult>>, DomainError>), 200)]
        [AllowAnonymous]
        [EnableRateLimiting("anon-limit")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await mediator.Send(new GetAllBlogModulesQuery()));
        }
        [HttpGet("GetById/{id}")]
        [ProducesResponseType(typeof(IResult<DomainSuccess<BlogModuleResult>, DomainError>), 200)]
        [AllowAnonymous]
        [EnableRateLimiting("anon-limit")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await mediator.Send(new GetBlogModuleByIdQuery(id)));
        }
        [HttpGet("GetByBlogId/{blogId}")]
        [ProducesResponseType(typeof(IResult<DomainSuccess<List<BlogModuleResult>>, DomainError>), 200)]
        [AllowAnonymous]
        [EnableRateLimiting("anon-limit")]
        public async Task<IActionResult> GetByBlogId(int blogId)
        {
            return Ok(await mediator.Send(new GetBlogModulesByBlogIdQuery(blogId)));
        }
        [HttpPost("Create")]
        [ProducesResponseType(typeof(IResult<DomainSuccess<BlogModuleResult>, DomainError>), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        public async Task<IActionResult> Create(CreateBlogModuleCommand command)
        {
            return Ok(await mediator.Send(command));
        }
        [HttpPut("Update")]
        [ProducesResponseType(typeof(IResult<DomainSuccess<BlogModuleResult>, DomainError>), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        public async Task<IActionResult> Update(UpdateBlogModuleCommand command)
        {
            return Ok(await mediator.Send(command));
        }
        [HttpDelete("Delete/{id}")]
        [ProducesResponseType(typeof(IResult<DomainSuccess<int>, DomainError>), 200)]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await mediator.Send(new DeleteBlogModuleCommand(id)));
        }
    }
}
