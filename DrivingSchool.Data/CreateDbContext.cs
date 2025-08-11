using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DrivingSchool.Data
{
    public class DrivingSchoolDbContextFactory : IDesignTimeDbContextFactory<DrivingSchoolDbContext>
    {
        public DrivingSchoolDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DrivingSchoolDbContext>();
            optionsBuilder.UseSqlServer("Server=DESKTOP-R5FGUF6\\SQLEXPRESS;Database=DrivingSchool;Trusted_Connection=True;TrustServerCertificate=True");

            return new DrivingSchoolDbContext(optionsBuilder.Options);
        }
    }
}
