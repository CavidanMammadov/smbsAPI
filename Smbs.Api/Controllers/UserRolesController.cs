using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Smbs.Application.Features.MediatR.Commands.Roles;
using Smbs.Domain;
using Smbs.Domain.Results;

namespace Smbs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class UserRolesController(IMediator mediator) : ControllerBase
    {    //user role yaratmaq ucun endpoint
        [HttpPost]
        [ProducesResponseType(typeof(IResult<DomainSuccess<Smbs.Application.Features.MediatR.Results.Roles.UserRoleResult>, DomainError>), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        public async Task<IActionResult> Create(CreateUserRoleCommand command)
        {
            var result = await mediator.Send(command);
            return Ok(result);
        }
    }
}
