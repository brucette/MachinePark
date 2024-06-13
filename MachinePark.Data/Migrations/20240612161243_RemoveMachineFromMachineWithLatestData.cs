using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MachinePark.Data.Migrations
{
    /// <inheritdoc />
    public partial class RemoveMachineFromMachineWithLatestData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReceivedData_Machines_MachineId",
                table: "ReceivedData");

            migrationBuilder.DropIndex(
                name: "IX_ReceivedData_MachineId",
                table: "ReceivedData");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ReceivedData_MachineId",
                table: "ReceivedData",
                column: "MachineId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReceivedData_Machines_MachineId",
                table: "ReceivedData",
                column: "MachineId",
                principalTable: "Machines",
                principalColumn: "MachineId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
