using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TZ.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Experiments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("a3dc9081-6dc1-4cf1-9e44-cefe22f97e85"), "button_color" },
                    { new Guid("eb63b870-0675-4dbe-89d7-3e64bdb21f31"), "price" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Experiments",
                keyColumn: "Id",
                keyValue: new Guid("a3dc9081-6dc1-4cf1-9e44-cefe22f97e85"));

            migrationBuilder.DeleteData(
                table: "Experiments",
                keyColumn: "Id",
                keyValue: new Guid("eb63b870-0675-4dbe-89d7-3e64bdb21f31"));
        }
    }
}
