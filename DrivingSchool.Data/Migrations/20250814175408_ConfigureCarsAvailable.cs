using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DrivingSchool.Data.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureCarsAvailable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9c9d7d8b-b2f6-4a3d-a7b1-4b75e7c26e59",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "642be0a6-86fa-457a-8f8f-8f684a32acd1", "AQAAAAIAAYagAAAAEAEfnDOy45fgsUfFdueEvaNEZXOQgRVixJzNN3qrWFcEZWUUOUwnNTjzEdzW9+gH7w==" });

            migrationBuilder.InsertData(
                table: "CarsAvailable",
                columns: new[] { "ActivityId", "CarsId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 3, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CarsAvailable",
                keyColumns: new[] { "ActivityId", "CarsId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CarsAvailable",
                keyColumns: new[] { "ActivityId", "CarsId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "CarsAvailable",
                keyColumns: new[] { "ActivityId", "CarsId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9c9d7d8b-b2f6-4a3d-a7b1-4b75e7c26e59",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "f2e69b1d-be1d-44ad-bd89-b4e598be07b3", "AQAAAAIAAYagAAAAEBTpNvrIeoiqcgQMACeJzXudGluAj3hSJLOvazZVnDf6puOOdr801v3JhUxaMnjq0Q==" });
        }
    }
}
