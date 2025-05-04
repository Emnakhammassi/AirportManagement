using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructeur.Migrations
{
    /// <inheritdoc />
    public partial class AddPilotToFlight : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FlightId",
                table: "Staffs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Pilot",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Staffs_FlightId",
                table: "Staffs",
                column: "FlightId");

            migrationBuilder.AddForeignKey(
                name: "FK_Staffs_Flights_FlightId",
                table: "Staffs",
                column: "FlightId",
                principalTable: "Flights",
                principalColumn: "FlightId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Staffs_Flights_FlightId",
                table: "Staffs");

            migrationBuilder.DropIndex(
                name: "IX_Staffs_FlightId",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "FlightId",
                table: "Staffs");

            migrationBuilder.DropColumn(
                name: "Pilot",
                table: "Flights");
        }
    }
}
