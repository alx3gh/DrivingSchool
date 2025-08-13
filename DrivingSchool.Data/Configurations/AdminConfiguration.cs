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
    public class AdminConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder
                .HasData(new IdentityUserRole<string>
                {
                    RoleId = "Administrator",
                    UserId = "9c9d7d8b-b2f6-4a3d-a7b1-4b75e7c26e59"
                });
        }
    }
}
