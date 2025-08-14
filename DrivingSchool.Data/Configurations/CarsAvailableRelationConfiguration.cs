using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DrivingSchool.Models;

namespace DrivingSchool.Data.Configurations
{
    public class CarsAvailableRelationConfiguration : IEntityTypeConfiguration<CarsAvailable>
    {
        public void Configure(EntityTypeBuilder<CarsAvailable> builder)
        {
            builder.HasData(

                    new CarsAvailable { CarsId = 1, ActivityId = 1 },
                    new CarsAvailable { CarsId = 2, ActivityId = 2 },
                    new CarsAvailable { CarsId = 3, ActivityId = 3 });

        }
    }
}
