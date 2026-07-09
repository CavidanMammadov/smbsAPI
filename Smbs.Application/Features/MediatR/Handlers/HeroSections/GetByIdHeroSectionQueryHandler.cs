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
    public class GetByIdHeroSectionQueryHandler(IRepository<HeroSection> repository) : IRequestHandler<GetByIdHeroSectionQuery, IResult<DomainSuccess<ResultHeroSectionDto>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<ResultHeroSectionDto>, DomainError>> Handle(GetByIdHeroSectionQuery request, CancellationToken cancellationToken)
        {
            var value =await repository.GetById(request.Id);
            if (value == null)
            {
                return Result.Fail<ResultHeroSectionDto>(DomainError.NotFound("HeroSection not found"));
            }
            return Result.Success(DomainSuccess<ResultHeroSectionDto>.OK(new ResultHeroSectionDto
            {
                HeroSectionId = value.HeroSectionId,
                HeroSectionTitle = value.HeroSectionTitle,
                HeroSectionDescription = value.HeroSectionDescription
            }, "Retrieved successfully"));
        }
    }
}
