using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Smbs.Application.Features.MediatR.Commands.AboutUs;
using Smbs.Application.Features.MediatR.Queries.AboutUs;
using Smbs.Application.Features.MediatR.Results.AboutUs;
using Smbs.Domain.Results;
using Smbs.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.RateLimiting;

namespace Smbs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AboutUsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AboutUsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [Consumes("multipart/form-data")]
        [ProducesResponseType(typeof(IResult<DomainSuccess<CreateAboutUsResult>, DomainError>), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        public async Task<IActionResult> Create([FromForm]CreateAboutUsCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpGet("GetAll")]
        [AllowAnonymous]
        [EnableRateLimiting("anon-limit")]
        [ProducesResponseType(typeof(IResult<DomainSuccess<List<GetAboutUsResult>>, DomainError>), 200)]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetAllAboutUsQuery()));
        }
        [HttpGet("GetById")]
        [AllowAnonymous]
        [EnableRateLimiting("anon-limit")]
        [ProducesResponseType(typeof(IResult<DomainSuccess<GetByIdAboutUsResult>, DomainError>), 200)]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetByIdAboutUsQuery(id));
            return Ok(result);
        }
        [HttpPut]
        [Consumes("multipart/form-data")]
        [ProducesResponseType(typeof(IResult<DomainSuccess<UpdateAboutUsResult>, DomainError>), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        public async Task<IActionResult> Update([FromForm]UpdateAboutUsCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpDelete]
        [ProducesResponseType(typeof(IResult<DomainSuccess<int>, DomainError>), 200)]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteAboutUsCommand(id)));
        }
    }
}
