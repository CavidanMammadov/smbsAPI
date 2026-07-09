using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Smbs.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Smbs.Persistence.Configuration
{
    public class CorporateTrainingConfiguration : IEntityTypeConfiguration<CorporateTraining>
    {
        public void Configure(EntityTypeBuilder<CorporateTraining> builder)
        {
            builder.HasKey(x => x.CorporateTrainingId);

            builder.Property(x => x.CorporateTrainingCompanyName)
               .IsRequired();

            builder.Property(x => x.CorporateTrainingPosition)
                .IsRequired();


            builder.Property(x => x.CorporateTrainingDirection)
               .IsRequired();

            builder.Property(x => x.CorporateTrainingSchedule)
                .IsRequired();

            builder.Property(x => x.CorporateTrainingContactInfo)
               .IsRequired();

            builder.Property(x => x.CorporateTrainingEmployeeCount)
             .IsRequired();


            builder.Property(x => x.CorporateTrainingContractDate)
           .IsRequired();
        }
    }
}
