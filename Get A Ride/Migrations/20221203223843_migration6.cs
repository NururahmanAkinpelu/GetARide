using Microsoft.EntityFrameworkCore.Migrations;

namespace GetARide.Migrations
{
    public partial class migration6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Distance",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Bookings");

            migrationBuilder.AddColumn<int>(
                name: "Distance",
                table: "Trips",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Time",
                table: "Trips",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Distance",
                table: "Trips");

            migrationBuilder.DropColumn(
                name: "Time",
                table: "Trips");

            migrationBuilder.AddColumn<int>(
                name: "Distance",
                table: "Bookings",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Time",
                table: "Bookings",
                type: "int",
                nullable: true);
        }
    }
}
