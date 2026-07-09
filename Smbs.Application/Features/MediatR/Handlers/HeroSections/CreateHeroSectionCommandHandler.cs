using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Commands.HeroSections;
using Smbs.Application.Features.MediatR.Results.HeroSections;
using Smbs.Domain;
using Smbs.Domain.Entities;
using Smbs.Domain.Interfaces;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Handlers.HeroSections
{
    public class CreateHeroSectionCommandHandler(IRepository<HeroSection> repository) : IRequestHandler<CreateHeroSectionCommand, IResult<DomainSuccess<ResultHeroSectionDto>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<ResultHeroSectionDto>, DomainError>> Handle(CreateHeroSectionCommand request, CancellationToken cancellationToken)
        {
            var result = new HeroSection
            {
                HeroSectionDescription = request.HeroSectionDescription,
                HeroSectionTitle = request.HeroSectionTitle,

            };
           await repository.Create(result);
            return Result.Success(DomainSuccess<ResultHeroSectionDto>.Created(new ResultHeroSectionDto
            {
                HeroSectionId = result.HeroSectionId,
                HeroSectionDescription = request.HeroSectionDescription,
                HeroSectionTitle = request.HeroSectionTitle
            }, "Created successfully"));
        }
    }
}
