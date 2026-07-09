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
    public class ApplymentRepository : Repository<Applyment>, IApplymentRepository
    {
        public ApplymentRepository(AppDbContext context) : base(context)
        {
        }
    }
}
