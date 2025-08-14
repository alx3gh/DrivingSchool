using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DrivingSchool.Data.Migrations
{
    /// <inheritdoc />
    public partial class ConfigureTrack : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9c9d7d8b-b2f6-4a3d-a7b1-4b75e7c26e59",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "17a822e8-1e2e-4981-a553-cc581d9103c1", "AQAAAAIAAYagAAAAEH+vqSbprgn3l0sQKEWOlD1W348mzC4S9wGOk52vgXh6nliajcGYLz6PQwpKsHmknQ==" });

            migrationBuilder.InsertData(
                table: "Track",
                columns: new[] { "Id", "Description", "ImageUrl", "Location", "Name" },
                values: new object[,]
                {
                    { 1, "The Dragon Circuit is the first and only track for motorsports and motorcycle racing in Bulgaria.", "/images/track1.png", "Bulgaria", "Drakon Circuit" },
                    { 2, "The Serres Circuit track, is the most popular and most used by high-speed enthusiasts in our country. It is located near a small Greek town.", "/images/track2.png", "Greece", "Serres Circuit" },
                    { 3, "The NAVAK Car Track is located not far from the capital Belgrade. It is part of the NAVAK training center.", "/images/track3.png", "Serbia", "NAVAK Car Track" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Track",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Track",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Track",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9c9d7d8b-b2f6-4a3d-a7b1-4b75e7c26e59",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "9b10193a-ba13-4b7f-a003-faffffa2013b", "AQAAAAIAAYagAAAAEGodvuv2c1hxgljqQE86ZncmDd90MotEbNxPU9Wvn8b2lQuDvb9riac2BnVMt5z+uw==" });
        }
    }
}
