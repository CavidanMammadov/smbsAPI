using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Queries.HeroSections;
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
    public class GetAllHeroSectionQueryHandler(IRepository<HeroSection> repository) : IRequestHandler<GetAllHeroSectionQuery, IResult<DomainSuccess<List<ResultHeroSectionDto>>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<List<ResultHeroSectionDto>>, DomainError>> Handle(GetAllHeroSectionQuery request, CancellationToken cancellationToken)
        {
            var value =await repository.GetAll();
            if (value == null)
            {
                return Result.Fail<List<ResultHeroSectionDto>>(DomainError.NotFound("No hero sections found"));
            }
            return Result.Success(DomainSuccess<List<ResultHeroSectionDto>>.OK(value.Select(heroSection => new ResultHeroSectionDto
            {
                HeroSectionId = heroSection.HeroSectionId,
                HeroSectionTitle = heroSection.HeroSectionTitle,
                HeroSectionDescription = heroSection.HeroSectionDescription
            }).ToList(), "Retrieved successfully"));
        }
    }
}
