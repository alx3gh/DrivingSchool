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
    public class LessonsConfiguration : IEntityTypeConfiguration<Lessons>
    {
        public void Configure(EntityTypeBuilder<Lessons> builder)
        {
            builder.HasData(
                new Lessons
                {
                    Id = 1,
                    Name = "Racing training with laps",
                    Description = "Learn competitive track driving techniques, from cornering to overtaking, in a controlled circuit environment.",
                    Price = 260,
                    DriversId = 1
                },

                new Lessons
                {
                    Id = 2,
                    Name = "Drag Lessons",
                    Description = "Master launch control, reaction time, and straight-line speed for head-to-head quarter-mile runs.",
                    Price = 450,
                    DriversId = 2
                },

                new Lessons
                {
                    Id = 3,
                    Name = "Rally & Off-Road Lessons",
                    Description = "Train in off-road driving skills, navigation, and handling across challenging terrain and conditions.",
                    Price = 380,
                    DriversId = 3
                }

            );
        }
    }
}
