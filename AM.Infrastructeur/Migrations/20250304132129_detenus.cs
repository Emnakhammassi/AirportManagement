using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructeur.Migrations
{
    /// <inheritdoc />
    public partial class detenus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Lastname",
                table: "Passengers",
                newName: "FullName_Lastname");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "Passengers",
                newName: "FullName_FirstName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName_Lastname",
                table: "Passengers",
                newName: "Lastname");

            migrationBuilder.RenameColumn(
                name: "FullName_FirstName",
                table: "Passengers",
                newName: "FirstName");
        }
    }
}
