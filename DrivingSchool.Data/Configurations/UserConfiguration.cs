using DrivingSchool.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingSchool.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        private readonly IPasswordHasher<AppUser?> _passwordHasher = new PasswordHasher<AppUser?>();
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder
                .HasData(new AppUser
                {

                    Id = "9c9d7d8b-b2f6-4a3d-a7b1-4b75e7c26e59",
                    UserName = "admin1",
                    NormalizedUserName = "ADMIN1",
                    Email = "admin1@abv.com",
                    NormalizedEmail = "ADMIN1@ABV.COM",
                    PasswordHash = _passwordHasher.HashPassword(null, "admin1!"),
                    SecurityStamp = "SecurityStampTest01"
                });
        }
    }
}
