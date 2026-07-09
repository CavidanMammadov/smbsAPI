using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Smbs.Application.Features.MediatR.Commands.Applyments;
using Smbs.Application.Features.MediatR.Queries.Applyments;
using Smbs.Application.Features.MediatR.Results.Applyments;
using Smbs.Domain;
using Smbs.Domain.Results;

namespace Smbs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class ApplymentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ApplymentsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [ProducesResponseType(typeof(IResult<DomainSuccess<CreateApplymentResult>, DomainError>), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [AllowAnonymous]
        [EnableRateLimiting("anon-limit")]
        public async Task<IActionResult> Create(CreateApplymentCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpGet]
        [AllowAnonymous]
        [EnableRateLimiting("anon-limit")]
        [ProducesResponseType(typeof(IResult<DomainSuccess<List<GetApplymentByIdResult>>, DomainError>), 200)]

        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetApplymentsQuery()));
        }
        [HttpGet("GetById")]
        [AllowAnonymous]
        [EnableRateLimiting("anon-limit")]
        [ProducesResponseType(typeof(IResult<DomainSuccess<GetApplymentByIdResult>, DomainError>), 200)]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _mediator.Send(new GetApplymentByIdQuery(id)));
        }
        [HttpPut]
        [ProducesResponseType(typeof(IResult<DomainSuccess<UpdateApplymentResult>, DomainError>), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        public async Task<IActionResult> Update(UpdateApplymentCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpDelete]
        [ProducesResponseType(typeof(IResult<DomainSuccess<int>, DomainError>), 200)]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new DeleteApplymentCommand(id)));
        }

        /// <summary>
        /// Get all applyments with pagination support.
        /// Use pageNumber and pageSize query parameters.
        /// </summary>
        /// <param name="query">Pagination query (pageNumber, pageSize)</param>
        /// <returns>Paged list of applyments with total count</returns>
        [HttpGet("GetAllWithPagination")]
        [AllowAnonymous]
        [EnableRateLimiting("anon-limit")]
        [ProducesResponseType(typeof(IResult<DomainSuccess<PaginatedResult<ResultApplymentDto>>, DomainError>), 200)]
        public async Task<IActionResult> GetAllWithPagination([FromQuery] GetApplymentsWithPaginationQuery query)
        {
            return Ok(await _mediator.Send(query));
        }
    }
}