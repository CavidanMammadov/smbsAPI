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
    public class UpdateHeroSectionCommandHandler(IRepository<HeroSection> repository) : IRequestHandler<UpdateHeroSectionCommand, IResult<DomainSuccess<ResultHeroSectionDto>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<ResultHeroSectionDto>, DomainError>> Handle(UpdateHeroSectionCommand request, CancellationToken cancellationToken)
        {
            var value=await repository.GetById(request.HeroSectionId);
            if(value == null)
            {
                return Result.Fail<ResultHeroSectionDto>(DomainError.NotFound("Hero section not found"));
            }
           await repository.Update(new HeroSection
            {
                HeroSectionId = request.HeroSectionId,
                HeroSectionTitle = request.HeroSectionTitle,
                HeroSectionDescription = request.HeroSectionDescription
            });
            return Result.Success(DomainSuccess<ResultHeroSectionDto>.OK(new ResultHeroSectionDto
            {HeroSectionId = request.HeroSectionId,
                HeroSectionTitle = request.HeroSectionTitle,
                HeroSectionDescription = request.HeroSectionDescription
            }, "Updated successfully"));
        }
    }
}
