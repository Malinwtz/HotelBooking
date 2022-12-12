using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBooking.Migrations
{
    public partial class ChangedBookingIdtoId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Rooms",
                newName: "RoomId");

            migrationBuilder.RenameColumn(
                name: "BookingId",
                table: "Bookings",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "Rooms",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Bookings",
                newName: "BookingId");
        }
    }
}
