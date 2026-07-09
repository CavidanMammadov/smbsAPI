using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Smbs.Domain;
using Smbs.Domain.Results;

namespace Smbs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ProgramDownloadingsController(IMediator mediator) : ControllerBase
    {
        [HttpGet("GetAll")]
        [AllowAnonymous]
        [EnableRateLimiting("anon-limit")]
        [ProducesResponseType(typeof(IResult<DomainSuccess<List<Smbs.Application.Features.MediatR.Results.ProgramDownloadings.ProgramDownloadingResult>>, DomainError>), 200)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await mediator.Send(new Smbs.Application.Features.MediatR.Queries.ProgramDownloadings.GetAllProgramDownloadingQuery()));
        }
        [HttpGet("GetById{id}")]
        [AllowAnonymous]
        [EnableRateLimiting("anon-limit")]
        [ProducesResponseType(typeof(IResult<DomainSuccess<Smbs.Application.Features.MediatR.Results.ProgramDownloadings.ProgramDownloadingResult>, DomainError>), 200)]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await mediator.Send(new Smbs.Application.Features.MediatR.Queries.ProgramDownloadings.GetByIdProgramDownloadingQuery(id)));
        }
        [HttpPost("Create")]
        [ProducesResponseType(typeof(IResult<DomainSuccess<Smbs.Application.Features.MediatR.Results.ProgramDownloadings.ProgramDownloadingResult>, DomainError>), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [AllowAnonymous]
        [EnableRateLimiting("anon-limit")]
        public async Task<IActionResult> Create(Smbs.Application.Features.MediatR.Commands.ProgramDownloadings.CreateProgramDownloadingCommand command)
        {
            return Ok(await mediator.Send(command));
        }
        [HttpPut]
        [ProducesResponseType(typeof(IResult<DomainSuccess<Smbs.Application.Features.MediatR.Results.ProgramDownloadings.ProgramDownloadingResult>, DomainError>), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        public async Task<IActionResult> Update(Smbs.Application.Features.MediatR.Commands.ProgramDownloadings.UpdateProgramDownloadingCommand command)
        {
            return Ok(await mediator.Send(command));
        }
        [HttpDelete]
        [ProducesResponseType(typeof(IResult<DomainSuccess<int>, DomainError>), 200)]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await mediator.Send(new Smbs.Application.Features.MediatR.Commands.ProgramDownloadings.DeleteProgramDownloadingCommand(id)));
        }
    }
}
