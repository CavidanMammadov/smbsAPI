using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Smbs.Application.Features.MediatR.Results.Advice;
using Smbs.Domain.Results;
using Smbs.Domain;
using Microsoft.AspNetCore.RateLimiting;

namespace Smbs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdviceTitlesController(IMediator mediator) : ControllerBase
    {
        [HttpGet("GetAll")]
        [AllowAnonymous]
        [EnableRateLimiting("anon-limit")]
        [ProducesResponseType(typeof(IResult<DomainSuccess<List<GetAllAdviceResult>>, DomainError>), 200)]
        public async Task<IActionResult> GetAll()
        {
            var result = await mediator.Send(new Application.Features.MediatR.Queries.AdviceTitles.GetAllAdviceTitlesQuery());
            return Ok(result);
        }
        [HttpGet("GetById/{id}")]
        [AllowAnonymous]
        [EnableRateLimiting("anon-limit")]
        [ProducesResponseType(typeof(IResult<DomainSuccess<GetByIdAdviceResult>, DomainError>), 200)]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await mediator.Send(new Application.Features.MediatR.Queries.AdviceTitles.GetByIdAdviceTitleQuery(id));
            return Ok(result);
        }
        [HttpPost("Create")]
        [ProducesResponseType(typeof(IResult<DomainSuccess<CreateAdviceResult>, DomainError>), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        public async Task<IActionResult> Create(Application.Features.MediatR.Commands.AdviceTitles.CreateAdviceTitleCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }
        [HttpPut("Update")]
        [ProducesResponseType(typeof(IResult<DomainSuccess<CreateAdviceResult>, DomainError>), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        public async Task<IActionResult> Update(Application.Features.MediatR.Commands.AdviceTitles.UpdateAdviceTitleCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }
        [HttpDelete("Delete/{id}")]
        [ProducesResponseType(typeof(IResult<DomainSuccess<int>, DomainError>), 200)]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await mediator.Send(new Application.Features.MediatR.Commands.AdviceTitles.DeleteAdviceTitleCommand(id));
            return Ok(result);
        }
    }
}
