using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Results.Applyments;
using Smbs.Domain;
using Smbs.Domain.Results;

namespace Smbs.Application.Features.MediatR.Commands.Applyments
{
    public class DeleteApplymentCommand : IRequest<IResult<DomainSuccess<int>,DomainError>>
    {
        public int Id { get; set; }

        public DeleteApplymentCommand(int id)
        {
            Id = id;
        }
    }
}
