using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachinePark.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeModelling : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastUpdated",
                table: "Machines");

            migrationBuilder.DropColumn(
                name: "LatestReceivedData",
                table: "Machines");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "ReceivedData",
                newName: "Data");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Data",
                table: "ReceivedData",
                newName: "Description");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastUpdated",
                table: "Machines",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LatestReceivedData",
                table: "Machines",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
