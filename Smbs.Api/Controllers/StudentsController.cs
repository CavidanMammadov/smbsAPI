using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Smbs.Application.Features.MediatR.Commands.Students;
using Smbs.Domain;
using Smbs.Domain.Results;

namespace Smbs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class StudentsController(IMediator mediator) : ControllerBase
    {
        [HttpPost("Create")]
        [ProducesResponseType(typeof(IResult<DomainSuccess<Smbs.Application.Features.MediatR.Results.Students.StudentResult>, DomainError>), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        public async Task<IActionResult> Create(CreateStudentCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpGet("GetAll")]
        [AllowAnonymous]
        [EnableRateLimiting("anon-limit")]
        [ProducesResponseType(typeof(IResult<DomainSuccess<List<Smbs.Application.Features.MediatR.Results.Students.StudentResult>>, DomainError>), 200)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await mediator.Send(new Application.Features.MediatR.Queries.Students.GetAllStudentsQuery()));
        }

        [HttpGet("GetWithPagination")]
        [AllowAnonymous]
        [EnableRateLimiting("anon-limit")]
        [ProducesResponseType(typeof(IResult<DomainSuccess<PaginatedResult<Smbs.Application.Features.MediatR.Results.Students.StudentResult>>, DomainError>), 200)]
        public async Task<IActionResult> GetWithPagination([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var query = new Application.Features.MediatR.Queries.Students.GetStudentsWithPaginationQuery(pageNumber, pageSize);
            return Ok(await mediator.Send(query));
        }

        [HttpGet("GetById/{id}")]
        [AllowAnonymous]
        [EnableRateLimiting("anon-limit")]
        [ProducesResponseType(typeof(IResult<DomainSuccess<Smbs.Application.Features.MediatR.Results.Students.StudentResult>, DomainError>), 200)]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await mediator.Send(new Application.Features.MediatR.Queries.Students.GetByIdStudentQuery(id)));
        }

        [HttpDelete("Delete/{id}")]
        [ProducesResponseType(typeof(IResult<DomainSuccess<int>, DomainError>), 200)]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await mediator.Send(new Application.Features.MediatR.Commands.Students.DeleteStudentCommand(id)));
        }

        [HttpPut("Update")]
        [ProducesResponseType(typeof(IResult<DomainSuccess<Smbs.Application.Features.MediatR.Results.Students.StudentResult>, DomainError>), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        public async Task<IActionResult> Update(UpdateStudentCommand command)
        {
            return Ok(await mediator.Send(command));

        }
    }
}