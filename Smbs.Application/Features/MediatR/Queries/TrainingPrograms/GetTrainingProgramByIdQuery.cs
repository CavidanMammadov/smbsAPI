using MediatR;
using Microsoft.AspNetCore.Http;
using Smbs.Application.Features.MediatR.Results.TrainingPrograms;
using Smbs.Domain;
using Smbs.Domain.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Application.Features.MediatR.Queries.TrainingPrograms
{
    public class GetTrainingProgramByIdQuery:IRequest<IResult<DomainSuccess<TrainingProgramResult>,DomainError>>
    {
        public int Id { get; set; }

        public GetTrainingProgramByIdQuery(int id)
        {
            Id = id;
        }
    }
}
