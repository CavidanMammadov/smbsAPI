using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Smbs.Application.Features.MediatR.Queries.TrainingPrograms;
using Smbs.Application.Features.MediatR.Results.AboutUs;
using Smbs.Domain.Results;
using Smbs.Domain;
using Smbs.Application.Features.MediatR.Commands.TrainingPrograms;
using Microsoft.AspNetCore.RateLimiting;

namespace Smbs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class TrainingProgramsController(IMediator mediator) : ControllerBase
    {
        [HttpGet("GetAll")]
        [AllowAnonymous]
        [EnableRateLimiting("anon-limit")]
        [ProducesResponseType(typeof(IResult<DomainSuccess<List<GetAboutUsResult>>, DomainError>), 200)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await mediator.Send(new GetAllTrainingProgramsQuery()));
        }
        [HttpGet("GetById")]
        [AllowAnonymous]
        [EnableRateLimiting("anon-limit")]
        [ProducesResponseType(typeof(IResult<DomainSuccess<GetByIdAboutUsResult>, DomainError>), 200)]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await mediator.Send(new GetTrainingProgramByIdQuery(id));
            return Ok(result);
        }
        [HttpPut("Update")]

        [ProducesResponseType(typeof(IResult<DomainSuccess<UpdateAboutUsResult>, DomainError>), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        public async Task<IActionResult> Update([FromForm] UpdateTrainingProgramCommand command)
        {
            return Ok(await mediator.Send(command));
        }
        [HttpDelete("Delete")]
        [ProducesResponseType(typeof(IResult<DomainSuccess<int>, DomainError>), 200)]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await mediator.Send(new DeleteTrainingProgramCommand(id)));

        }
        [HttpPost("Create")]
    
        [ProducesResponseType(typeof(IResult<DomainSuccess<CreateAboutUsResult>, DomainError>), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        public async Task<IActionResult> Create([FromForm] CreateTrainingProgramCommand command)
        {
            return Ok(await mediator.Send(command));
        }
    }
}
