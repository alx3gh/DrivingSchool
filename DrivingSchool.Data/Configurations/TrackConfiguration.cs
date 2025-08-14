using DrivingSchool.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingSchool.Data.Configurations
{

    public class TrackConfiguration : IEntityTypeConfiguration<Track>
    {
        public void Configure(EntityTypeBuilder<Track> builder)
        {
            builder
                .HasData(
                new Track
                {
                    Id = 1,
                    Name = "Drakon Circuit",
                    Location = "Bulgaria",
                    Description = "The Dragon Circuit is the first and only track for motorsports and motorcycle racing in Bulgaria.",
                    ImageUrl = "/images/track1.png"
                },
                new Track
                {
                    Id = 2,
                    Name = "Serres Circuit",
                    Location = "Greece",
                    Description = "The Serres Circuit track, is the most popular and most used by high-speed enthusiasts in our country. It is located near a small Greek town.",
                    ImageUrl = "/images/track2.png"
                },
                new Track
                {
                    Id = 3,
                    Name = "NAVAK Car Track",
                    Location = "Serbia",
                    Description = "The NAVAK Car Track is located not far from the capital Belgrade. It is part of the NAVAK training center.",
                    ImageUrl = "/images/track3.png"
                });
        }
    }
}
