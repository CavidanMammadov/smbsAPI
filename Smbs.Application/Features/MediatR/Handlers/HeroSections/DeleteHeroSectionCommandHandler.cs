using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Commands.HeroSections;
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
    public class DeleteHeroSectionCommandHandler(IRepository<HeroSection> repository) : IRequestHandler<DeleteHeroSectionCommand, IResult<DomainSuccess<int>, DomainError>>
    {
        public async Task<IResult<DomainSuccess<int>, DomainError>> Handle(DeleteHeroSectionCommand request, CancellationToken cancellationToken)
        {
            var value = await repository.GetById(request.Id);
            await repository.Delete(value);
            return Result.Success(DomainSuccess<int>.OK(request.Id, "Deleted successfully"));
        }
    }
}
