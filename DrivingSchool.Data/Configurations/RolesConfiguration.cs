using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace DrivingSchool.Data.Configurations
{
    public class RolesConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder
                .HasData(new IdentityRole { Id = "Administrator", Name = "Administrator", NormalizedName = "ADMINISTRATOR" });

            builder
                .HasData(new IdentityRole { Id = "User", Name = "User", NormalizedName = "USER" });
        }
    }
}
