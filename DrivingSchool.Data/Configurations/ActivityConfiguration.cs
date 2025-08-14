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
    public class ActivityConfiguration : IEntityTypeConfiguration<Activity>
    {
        public void Configure(EntityTypeBuilder<Activity> builder)
        {
            builder.HasData(
                new Activity
                {
                    Id = 1,
                    Name = "Circuit Racing",
                    Description = "This type of racing features stock cars (modified for racing) and is known for its oval track racing.",
                    ImageUrl = "/images/activity1.png",
                    TrackId = 1
                },

                new Activity
                {
                    Id = 2,
                    Name = "Drag Racing",
                    Description = "This type of racing involves accelerating from a standing start over a short distance, often a quarter-mile, with the focus on speed and quick acceleration. ",
                    ImageUrl = "/images/activity2.png",
                    TrackId = 2
                },

                new Activity
                {
                    Id = 3,
                    Name = "Rally Racing",
                    Description = "Rally races take place on public or closed roads, often in varied terrains and conditions. ",
                    ImageUrl = "/images/activity3.png",
                    TrackId = 3
                }

            );
        }
    }
}
