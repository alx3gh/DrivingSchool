using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DrivingSchool.Data.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureCars : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9c9d7d8b-b2f6-4a3d-a7b1-4b75e7c26e59",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f2e69b1d-be1d-44ad-bd89-b4e598be07b3", "AQAAAAIAAYagAAAAEBTpNvrIeoiqcgQMACeJzXudGluAj3hSJLOvazZVnDf6puOOdr801v3JhUxaMnjq0Q==" });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Description", "ImageUrl", "Name" },
                values: new object[,]
                {
                    { 1, "The Audi RS 4 is the high-performance variant of the Audi A4 range produced by Audi.", "/images/car1.png", "Audi RS4" },
                    { 2, "The BMW M3 is a high-performance version of the BMW 3 Series, developed by BMW's in-house motorsport division, BMW M.", "/images/car2.png", "BMW E46 M3" },
                    { 3, "The Toyota Yaris WRC is a World Rally Car designed by Toyota Gazoo Racing WRT to compete in the World Rally Championship.", "/images/car3.png", "Toyota Yaris WRC" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9c9d7d8b-b2f6-4a3d-a7b1-4b75e7c26e59",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e004159c-d47d-4ed9-bb86-5eec5a4bd194", "AQAAAAIAAYagAAAAEPuCWMjG1svIC0ENz8YPY2tkXhL7UXi9AAiykdgb4JAaVKHETQCbRcCUVW6I5j6Nyw==" });
        }
    }
}
