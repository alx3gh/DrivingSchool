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
    public class CarsConfiguration : IEntityTypeConfiguration<Cars>
    {
        public void Configure(EntityTypeBuilder<Cars> builder)
        {
            builder.HasData(
                new Cars
                {
                    Id = 1,
                    Name = "Audi RS4",
                    Description = "The Audi RS 4 is the high-performance variant of the Audi A4 range produced by Audi.",
                    ImageUrl = "/images/car1.png"
                },
                new Cars
                {
                    Id = 2,
                    Name = "BMW E46 M3",
                    Description = "The BMW M3 is a high-performance version of the BMW 3 Series, developed by BMW's in-house motorsport division, BMW M.",
                    ImageUrl = "/images/car2.png"
                },
                new Cars
                {
                    Id = 3,
                    Name = "Toyota Yaris WRC",
                    Description = "The Toyota Yaris WRC is a World Rally Car designed by Toyota Gazoo Racing WRT to compete in the World Rally Championship.",
                    ImageUrl = "/images/car3.png"
                }
                );
        }
    }
}
