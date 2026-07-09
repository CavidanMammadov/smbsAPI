using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Results.Trainers;
using Smbs.Application.Features.MediatR.Results.Users;
using Smbs.Domain;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Queries.Trainers
{
    public class GetByIdTrainerQuery:IRequest<IResult<DomainSuccess<TrainerResult>,DomainError>>
    {
        public int Id { get; set; }

        public GetByIdTrainerQuery(int id)
        {
            Id = id;
        }
    }
}
