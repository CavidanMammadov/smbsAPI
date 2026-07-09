using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Results.Services;
using Smbs.Domain;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Commands.Services
{
    public class UpdateServiceCommand:IRequest<IResult<DomainSuccess<ServiceResult>,DomainError>>
    {
        public int ServiceId { get; set; }
        public string ServiceTitle { get; set; }
        public string ServiceDescription { get; set; }
        public string ServiceIcon { get; set; }
    }
    public class UpdateServiceCommandValidator : AbstractValidator<UpdateServiceCommand>
    {
        public UpdateServiceCommandValidator()
        {
            RuleFor(x => x.ServiceTitle).NotEmpty().WithMessage("Service title is required.");
            RuleFor(x => x.ServiceDescription).NotEmpty().WithMessage("Service description is required.");
            RuleFor(x => x.ServiceIcon).NotEmpty().WithMessage("Service icon is required.");
        }
    }
}
