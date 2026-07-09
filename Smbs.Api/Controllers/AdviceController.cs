using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.RateLimiting;
using Smbs.Application.Features.MediatR.Commands.Advice;
using Smbs.Application.Features.MediatR.Queries.Advice;
using Smbs.Application.Features.MediatR.Results.AboutUs;
using Smbs.Application.Features.MediatR.Results.Advice;
using Smbs.Domain;
using Smbs.Domain.Results;
using System.Threading.Tasks;

namespace Smbs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AdviceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdviceController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet("GetAll")]
        [AllowAnonymous]
        [EnableRateLimiting("anon-limit")]
        [ProducesResponseType(typeof(IResult<DomainSuccess<List<GetAllAdviceResult>>, DomainError>), 200)]
        public async Task<IActionResult> Get()
        {
            return Ok(await _mediator.Send(new GetAllAdviceQuery()));
        }
        [HttpGet("{id}")]
        [AllowAnonymous]
        [EnableRateLimiting("anon-limit")]
        [ProducesResponseType(typeof(IResult<DomainSuccess<GetByIdAdviceResult>, DomainError>), 200)]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _mediator.Send(new GetByIdAdviceQuery(id)));
        }
        [HttpPost]
        [ProducesResponseType(typeof(IResult<DomainSuccess<CreateAdviceResult>, DomainError>), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        public async Task<IActionResult> Create(CreateAdviceCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpPut]
        [ProducesResponseType(typeof(IResult<DomainSuccess<CreateAdviceResult>, DomainError>), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        public async Task<IActionResult> Update(UpdateAdviceCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(IResult<DomainSuccess<int>, DomainError>), 200)]
        public async Task<IActionResult> DeleteAdvice(int id)
        {
            return Ok(await _mediator.Send(new DeleteAdviceCommand(id)));
        }
    }
}