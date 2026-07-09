using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Smbs.Application.Features.MediatR.Commands.Users;
using Smbs.Application.Features.MediatR.Queries.Users;
using Smbs.Domain;
using Smbs.Domain.Results;

namespace Smbs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class UsersController(IMediator mediator) : ControllerBase
    {    //user yaratmaq ucun endpoint
        [HttpPost]
        [EnableRateLimiting("anon-limit")]
        [ProducesResponseType(typeof(IResult<DomainSuccess<Smbs.Application.Features.MediatR.Results.Users.UserResult>, DomainError>), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        public async Task<IActionResult> Create([FromBody] CreateUserCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }
        //userName-e gore useri getirmek ucun endpoint
        [HttpGet]
        [EnableRateLimiting("anon-limit")]
        [ProducesResponseType(typeof(IResult<DomainSuccess<List<Smbs.Application.Features.MediatR.Results.Users.UserResult>>, DomainError>), 200)]
        public async Task<IActionResult> GetByUserName(string userName)
        {
            var result = await mediator.Send(new GetUserByUserNameQuery(userName));
            return Ok(result);
        }
        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok("API işləyir");
        }
    }
}
