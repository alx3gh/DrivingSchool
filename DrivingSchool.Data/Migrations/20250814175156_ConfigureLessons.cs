using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DrivingSchool.Data.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureLessons : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9c9d7d8b-b2f6-4a3d-a7b1-4b75e7c26e59",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e004159c-d47d-4ed9-bb86-5eec5a4bd194", "AQAAAAIAAYagAAAAEPuCWMjG1svIC0ENz8YPY2tkXhL7UXi9AAiykdgb4JAaVKHETQCbRcCUVW6I5j6Nyw==" });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "Description", "DriversId", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Learn competitive track driving techniques, from cornering to overtaking, in a controlled circuit environment.", 1, "Racing training with laps", 260 },
                    { 2, "Master launch control, reaction time, and straight-line speed for head-to-head quarter-mile runs.", 2, "Drag Lessons", 450 },
                    { 3, "Train in off-road driving skills, navigation, and handling across challenging terrain and conditions.", 3, "Rally & Off-Road Lessons", 380 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9c9d7d8b-b2f6-4a3d-a7b1-4b75e7c26e59",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4afb9030-2cb8-4280-a2dc-f598eb86b059", "AQAAAAIAAYagAAAAEOsmZLHfYn+TXcDKKPbl+4Ec14l+o2eWsKuioCVzl4qmqv2ft0rzh9STSMdJHgwwoQ==" });
        }
    }
}
