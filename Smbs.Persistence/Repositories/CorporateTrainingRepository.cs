using Smbs.Domain.Entities;
using Smbs.Domain.Interfaces;
using Smbs.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Persistence.Repositories
{
    public class CorporateTrainingRepository :Repository<CorporateTraining> , ICorporateTrainingRepository
    {
        public CorporateTrainingRepository(AppDbContext context): base(context)
        {
            
        }
    }
}
