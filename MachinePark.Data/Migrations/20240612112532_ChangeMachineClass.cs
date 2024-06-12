using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachinePark.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeMachineClass : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LastDataReceived",
                table: "Machines",
                newName: "LastUpdated");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Machines",
                newName: "MachineId");

            migrationBuilder.AddColumn<string>(
                name: "LatestReceivedData",
                table: "Machines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Machines",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ReceivedData",
                columns: table => new
                {
                    ReceivedDataId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReceivedData", x => x.ReceivedDataId);
                    table.ForeignKey(
                        name: "FK_ReceivedData_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "MachineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReceivedData_MachineId",
                table: "ReceivedData",
                column: "MachineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReceivedData");

            migrationBuilder.DropColumn(
                name: "LatestReceivedData",
                table: "Machines");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Machines");

            migrationBuilder.RenameColumn(
                name: "LastUpdated",
                table: "Machines",
                newName: "LastDataReceived");

            migrationBuilder.RenameColumn(
                name: "MachineId",
                table: "Machines",
                newName: "Id");
        }
    }
}
