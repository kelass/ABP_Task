using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TZ.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeyOfExperiment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ExperimentId",
                table: "ExperimentResults",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_ExperimentResults_ExperimentId",
                table: "ExperimentResults",
                column: "ExperimentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ExperimentResults_Experiments_ExperimentId",
                table: "ExperimentResults",
                column: "ExperimentId",
                principalTable: "Experiments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ExperimentResults_Experiments_ExperimentId",
                table: "ExperimentResults");

            migrationBuilder.DropIndex(
                name: "IX_ExperimentResults_ExperimentId",
                table: "ExperimentResults");

            migrationBuilder.DropColumn(
                name: "ExperimentId",
                table: "ExperimentResults");
        }
    }
}
