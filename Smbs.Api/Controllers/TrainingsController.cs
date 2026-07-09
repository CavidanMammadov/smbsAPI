using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Smbs.Application.Features.MediatR.Queries.Trainings;
using Smbs.Domain;
using Smbs.Domain.Results;

namespace Smbs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class TrainingsController(IMediator mediator) : ControllerBase
    {
        [HttpGet("GetAll")]
        [AllowAnonymous]
        [EnableRateLimiting("anon-limit")]
        [ProducesResponseType(typeof(IResult<DomainSuccess<List<Smbs.Application.Features.MediatR.Results.Trainings.TrainingResult>>, DomainError>), 200)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await mediator.Send(new GetAllTrainingsQuery()));
        }

        [HttpGet("GetWithPagination")]
        [AllowAnonymous]
        [EnableRateLimiting("anon-limit")]
        [ProducesResponseType(typeof(IResult<DomainSuccess<PaginatedResult<Smbs.Application.Features.MediatR.Results.Trainings.TrainingResult>>, DomainError>), 200)]
        public async Task<IActionResult> GetWithPagination([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var query = new Application.Features.MediatR.Queries.Trainings.GetTrainingsWithPaginationQuery(pageNumber, pageSize);
            return Ok(await mediator.Send(query));
        }

        [HttpGet("GetById/{id}")]
        [AllowAnonymous]
        [EnableRateLimiting("anon-limit")]
        [ProducesResponseType(typeof(IResult<DomainSuccess<Smbs.Application.Features.MediatR.Results.Trainings.TrainingResult>, DomainError>), 200)]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await mediator.Send(new GetByIdTrainingQuery(id)));
        }

        [HttpPost("Create")]
        [Consumes("multipart/form-data")]
        [ProducesResponseType(typeof(IResult<DomainSuccess<Smbs.Application.Features.MediatR.Results.Trainings.TrainingResult>, DomainError>), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        public async Task<IActionResult> Create([FromForm]Smbs.Application.Features.MediatR.Commands.Trainings.CreateTrainingCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpPut("Update")]
        [Consumes("multipart/form-data")]
        [ProducesResponseType(typeof(IResult<DomainSuccess<Smbs.Application.Features.MediatR.Results.Trainings.TrainingResult>, DomainError>), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        public async Task<IActionResult> Update([FromForm]Smbs.Application.Features.MediatR.Commands.Trainings.UpdateTrainingCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpDelete("Delete/{id}")]
        [ProducesResponseType(typeof(IResult<DomainSuccess<int>, DomainError>), 200)]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await mediator.Send(new Smbs.Application.Features.MediatR.Commands.Trainings.DeleteTrainingCommand(id)));
        }
    }
}
