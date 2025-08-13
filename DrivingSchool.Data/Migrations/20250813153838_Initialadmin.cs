using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DrivingSchool.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initialadmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9c9d7d8b-b2f6-4a3d-a7b1-4b75e7c26e59", 0, "9b10193a-ba13-4b7f-a003-faffffa2013b", "AppUser", "admin1@abv.com", false, false, null, "ADMIN1@ABV.COM", "ADMIN1", "AQAAAAIAAYagAAAAEGodvuv2c1hxgljqQE86ZncmDd90MotEbNxPU9Wvn8b2lQuDvb9riac2BnVMt5z+uw==", null, false, "SecurityStampTest01", false, "admin1" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "Administrator", "9c9d7d8b-b2f6-4a3d-a7b1-4b75e7c26e59" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "Administrator", "9c9d7d8b-b2f6-4a3d-a7b1-4b75e7c26e59" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9c9d7d8b-b2f6-4a3d-a7b1-4b75e7c26e59");
        }
    }
}
