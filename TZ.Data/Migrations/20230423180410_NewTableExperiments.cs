using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TZ.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewTableExperiments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DeviceToken",
                table: "Experiments");

            migrationBuilder.DropColumn(
                name: "Key",
                table: "Experiments");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "Experiments",
                newName: "Name");

            migrationBuilder.CreateTable(
                name: "ExperimentResults",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeviceToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperimentResults", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExperimentResults");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Experiments",
                newName: "Value");

            migrationBuilder.AddColumn<string>(
                name: "DeviceToken",
                table: "Experiments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Key",
                table: "Experiments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
