using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DrivingSchool.Data.Migrations
{
    /// <inheritdoc />
    public partial class Configureactivities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Activity",
                columns: new[] { "Id", "Description", "ImageUrl", "Name", "TrackId" },
                values: new object[,]
                {
                    { 1, "This type of racing features stock cars (modified for racing) and is known for its oval track racing.", "/images/activity1.png", "Circuit Racing", 1 },
                    { 2, "This type of racing involves accelerating from a standing start over a short distance, often a quarter-mile, with the focus on speed and quick acceleration. ", "/images/activity2.png", "Drag Racing", 2 },
                    { 3, "Rally races take place on public or closed roads, often in varied terrains and conditions. ", "/images/activity3.png", "Rally Racing", 3 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9c9d7d8b-b2f6-4a3d-a7b1-4b75e7c26e59",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "81635ca5-30fb-4b83-a4b8-7007d81fcb74", "AQAAAAIAAYagAAAAEA282K/gxaf0LjZVb67s4rVmFdG5cnmB2VWwQGRfFVFE62wVpJMvQquHlwV8fVf36g==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Activity",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Activity",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Activity",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9c9d7d8b-b2f6-4a3d-a7b1-4b75e7c26e59",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "17a822e8-1e2e-4981-a553-cc581d9103c1", "AQAAAAIAAYagAAAAEH+vqSbprgn3l0sQKEWOlD1W348mzC4S9wGOk52vgXh6nliajcGYLz6PQwpKsHmknQ==" });
        }
    }
}
