using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBooking.Migrations
{
    public partial class addedguestcountinbooking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GuestCount",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GuestCount",
                table: "Bookings");
        }
    }
}
