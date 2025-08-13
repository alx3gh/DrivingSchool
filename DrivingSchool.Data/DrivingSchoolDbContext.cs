using DrivingSchool.Data.Configurations;
using DrivingSchool.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DrivingSchool.Data
{
    public class DrivingSchoolDbContext : IdentityDbContext
    {
        public DrivingSchoolDbContext(DbContextOptions<DrivingSchoolDbContext> options)
            : base(options)
        {
        }
        public DbSet<Track> Track { get; set; } = null!;

        public DbSet<Drivers> Drivers { get; set; } = null!;

        public DbSet<Activity> Activity { get; set; } = null!;

        public DbSet<Lessons> Lessons { get; set; } = null!;

        public DbSet<Cars> Cars { get; set; } = null!;

        public DbSet<CarsAvailable> CarsAvailable { get; set; }

        public DbSet<AppUser> AppUsers { get; set; }

        public DbSet<UserLessons> UserLessons { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            var roles = new RolesConfiguration();
            builder.ApplyConfiguration<IdentityRole>(roles);

            var user = new UserConfiguration();
            builder.ApplyConfiguration<AppUser>(user);

            var admin = new AdminConfiguration();
            builder.ApplyConfiguration<IdentityUserRole<string>>(admin);


            base.OnModelCreating(builder);

            builder.Entity<CarsAvailable>()
           .HasKey(ca => new { ca.ActivityId, ca.CarsId });

            builder.Entity<CarsAvailable>()
                .HasOne(ca => ca.Activity)
                .WithMany(a => a.CarsAvailable)
                .HasForeignKey(ca => ca.CarsId);

            builder.Entity<CarsAvailable>()
                .HasOne(ca => ca.Cars)
                .WithMany(c => c.CarsAvailable)
                .HasForeignKey(ca => ca.CarsId);

            builder.Entity<UserLessons>()
                .HasKey(ul => new { ul.UserId, ul.LessonsId });

            builder.Entity<UserLessons>()
                .HasOne(ul => ul.User)
                .WithMany(u => u.UserLessons)
                .HasForeignKey(ul => ul.UserId);

            builder.Entity<UserLessons>()
                .HasOne(ul => ul.Lessons)
                .WithMany(l => l.UserLessons)
                .HasForeignKey(ul => ul.LessonsId);
        }
    }
}

