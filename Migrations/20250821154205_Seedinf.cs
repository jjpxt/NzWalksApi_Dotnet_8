using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NzWalksApi_Dotnet_8.Migrations
{
    /// <inheritdoc />
    public partial class Seedinf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0ae912b6-3d6d-4b1f-809a-ea83701543cd"), "Medium" },
                    { new Guid("6e2596b0-866d-4cb8-a799-12eee0ac2c60"), "Hard" },
                    { new Guid("9ee976ef-e1fe-4f41-8913-107a64a1c0f3"), "Eazy" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("1e2000b0-866d-4cb9-a799-14eee0ac2c61"), "NSL", "Nelson", "nelson_image.jpg" },
                    { new Guid("1e2555b0-666d-4cb8-a449-12eee0ac2c61"), "WGL", "Wellington", "welli.jpg" },
                    { new Guid("1e2596b0-866d-4cb8-a799-12eee0ac2c61"), "AUK", "Auckland", "auckland_image.jpg" },
                    { new Guid("1e3456b0-866d-4cb9-a111-14eee0ac2c61"), "STL", "Southland", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("0ae912b6-3d6d-4b1f-809a-ea83701543cd"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("6e2596b0-866d-4cb8-a799-12eee0ac2c60"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("9ee976ef-e1fe-4f41-8913-107a64a1c0f3"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("1e2000b0-866d-4cb9-a799-14eee0ac2c61"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("1e2555b0-666d-4cb8-a449-12eee0ac2c61"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("1e2596b0-866d-4cb8-a799-12eee0ac2c61"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("1e3456b0-866d-4cb9-a111-14eee0ac2c61"));
        }
    }
}
