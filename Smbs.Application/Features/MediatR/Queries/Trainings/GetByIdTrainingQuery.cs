using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Results.Trainings;
using Smbs.Domain;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Queries.Trainings
{
    public class GetByIdTrainingQuery:IRequest<IResult<DomainSuccess<TrainingResult>,DomainError>>
    {
        public int Id { get; set; }

        public GetByIdTrainingQuery(int id)
        {
            Id = id;
        }
    }
}
