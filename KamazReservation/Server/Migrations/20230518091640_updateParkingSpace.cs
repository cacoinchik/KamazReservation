using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KamazReservation.Server.Migrations
{
    /// <inheritdoc />
    public partial class updateParkingSpace : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsOccupied",
                table: "ParkingSpaces");

            migrationBuilder.AddColumn<int>(
                name: "Row",
                table: "ParkingSpaces",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Row",
                table: "ParkingSpaces");

            migrationBuilder.AddColumn<bool>(
                name: "IsOccupied",
                table: "ParkingSpaces",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
