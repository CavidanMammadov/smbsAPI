using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Smbs.Application.Features.MediatR.Commands.Trainers;
using Smbs.Application.Features.MediatR.Queries.Trainers;
using Smbs.Application.Features.MediatR.Results.Trainers;
 using Smbs.Domain;
using Smbs.Domain.Results;

namespace Smbs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class TrainersController(IMediator mediator) : ControllerBase
    {
        [HttpGet("GetAll")]
        [AllowAnonymous]
        [EnableRateLimiting("anon-limit")]
        [ProducesResponseType(typeof(IResult<DomainSuccess<List<TrainerResult>>, DomainError>), 200)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await mediator.Send(new GetAllTrainersQuery()));
        }
        [HttpGet("GetById/{id}")]
        [AllowAnonymous]
        [EnableRateLimiting("anon-limit")]
        [ProducesResponseType(typeof(IResult<DomainSuccess<TrainerResult>, DomainError>), 200)]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await mediator.Send(new GetByIdTrainerQuery(id)));
        }
        [HttpPut("Update")]
        [Consumes("multipart/form-data")]

        [ProducesResponseType(typeof(IResult<DomainSuccess<TrainerResult>, DomainError>), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        public async Task<IActionResult> Update([FromForm]UpdateTrainerCommand command)
        {
            return Ok(await mediator.Send(command));
        }
        [HttpPost("Create")]
        
        [ProducesResponseType(typeof(IResult<DomainSuccess<TrainerResult>, DomainError>), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        public async Task<IActionResult> Create(CreateTrainerCommand command)
        {
            return Ok(await mediator.Send(command));
        }
        [HttpDelete("Delete/{id}")]
        [ProducesResponseType(typeof(IResult<DomainSuccess<int>, DomainError>), 200)]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await mediator.Send(new DeleteTrainerCommand(id)));
        }
    }
}
