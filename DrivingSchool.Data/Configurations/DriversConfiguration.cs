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
    public class DriversConfiguration : IEntityTypeConfiguration<Drivers>
    {
        public void Configure(EntityTypeBuilder<Drivers> builder)
        {
            builder.HasData(
                new Drivers
                {
                    Id = 1,
                    Name = "Alexander Speed",
                    Age = 32,
                    Bio = "Expert at racing techniques, has many laps on Nurburgring.",
                    ImageUrl = "/images/driver1.png",
                    TrackId = 1
                },
                new Drivers
                {
                    Id = 2,
                    Name = "Josh Anthony",
                    Age = 29,
                    Bio = "Petrolhead and also a mechanic, Josh will teach you how to go fast",
                    ImageUrl = "/images/driver2.png",
                    TrackId = 2
                },
                new Drivers
                {
                    Id = 3,
                    Name = "Liam Ohaio",
                    Age = 36,
                    Bio = "Off-road and rally expert.",
                    ImageUrl = "/images/driver3.png",
                    TrackId = 3
                }
            );
        }
    }
}
