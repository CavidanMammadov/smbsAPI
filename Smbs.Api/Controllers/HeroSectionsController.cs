using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Smbs.Application.Features.MediatR.Commands.HeroSections;
using Smbs.Application.Features.MediatR.Queries.HeroSections;
using Smbs.Domain;
using Smbs.Domain.Results;

namespace Smbs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class HeroSectionsController(IMediator mediator) : ControllerBase
    {
        [HttpGet("GetAll")]
        [AllowAnonymous]
        [EnableRateLimiting("anon-limit")]
        [ProducesResponseType(typeof(IResult<DomainSuccess<List<Smbs.Application.Features.MediatR.Results.HeroSections.ResultHeroSectionDto>>, DomainError>), 200)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await mediator.Send(new GetAllHeroSectionQuery()));
        }
        [HttpGet("GetById{id}")]
        [AllowAnonymous]
        [EnableRateLimiting("anon-limit")]
        [ProducesResponseType(typeof(IResult<DomainSuccess<Smbs.Application.Features.MediatR.Results.HeroSections.ResultHeroSectionDto>, DomainError>), 200)]

        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await mediator.Send(new GetByIdHeroSectionQuery(id)));
        }
        [HttpPost("Create")]
        [ProducesResponseType(typeof(IResult<DomainSuccess<Smbs.Application.Features.MediatR.Results.HeroSections.ResultHeroSectionDto>, DomainError>), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        public async Task<IActionResult> Create(CreateHeroSectionCommand command)
        {
            return Ok(await mediator.Send(command));
        }
        [HttpPut]
        [ProducesResponseType(typeof(IResult<DomainSuccess<Smbs.Application.Features.MediatR.Results.HeroSections.ResultHeroSectionDto>, DomainError>), 200)]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        public async Task<IActionResult> Update(UpdateHeroSectionCommand command)
        {
            return Ok(await mediator.Send(command));
        }
        [HttpDelete]
        [ProducesResponseType(typeof(IResult<DomainSuccess<int>, DomainError>), 200)]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await mediator.Send(new DeleteHeroSectionCommand(id)));
        }
    }
}
