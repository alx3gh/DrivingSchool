using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DrivingSchool.Data.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureDrivers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9c9d7d8b-b2f6-4a3d-a7b1-4b75e7c26e59",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4afb9030-2cb8-4280-a2dc-f598eb86b059", "AQAAAAIAAYagAAAAEOsmZLHfYn+TXcDKKPbl+4Ec14l+o2eWsKuioCVzl4qmqv2ft0rzh9STSMdJHgwwoQ==" });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "Id", "Age", "Bio", "ImageUrl", "Name", "TrackId" },
                values: new object[,]
                {
                    { 1, 32, "Expert at racing techniques, has many laps on Nurburgring.", "/images/driver1.png", "Alexander Speed", 1 },
                    { 2, 29, "Petrolhead and also a mechanic, Josh will teach you how to go fast", "/images/driver2.png", "Josh Anthony", 2 },
                    { 3, 36, "Off-road and rally expert.", "/images/driver3.png", "Liam Ohaio", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Drivers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9c9d7d8b-b2f6-4a3d-a7b1-4b75e7c26e59",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "81635ca5-30fb-4b83-a4b8-7007d81fcb74", "AQAAAAIAAYagAAAAEA282K/gxaf0LjZVb67s4rVmFdG5cnmB2VWwQGRfFVFE62wVpJMvQquHlwV8fVf36g==" });
        }
    }
}
