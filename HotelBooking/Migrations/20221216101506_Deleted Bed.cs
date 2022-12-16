using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBooking.Migrations
{
    public partial class DeletedBed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Rooms_RoomId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Beds_BedId",
                table: "Rooms");

            migrationBuilder.DropTable(
                name: "Beds");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_BedId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_CustomerId",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_RoomId",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "Size",
                table: "Rooms",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "BedId",
                table: "Rooms",
                newName: "SizeSquareMeters");

            migrationBuilder.AddColumn<int>(
                name: "ExtraBed",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfGuests",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BookingRoom",
                columns: table => new
                {
                    BookingsBookingId = table.Column<int>(type: "int", nullable: false),
                    RoomsRoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingRoom", x => new { x.BookingsBookingId, x.RoomsRoomId });
                    table.ForeignKey(
                        name: "FK_BookingRoom_Bookings_BookingsBookingId",
                        column: x => x.BookingsBookingId,
                        principalTable: "Bookings",
                        principalColumn: "BookingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingRoom_Rooms_RoomsRoomId",
                        column: x => x.RoomsRoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CustomerId",
                table: "Bookings",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingRoom_RoomsRoomId",
                table: "BookingRoom",
                column: "RoomsRoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingRoom");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_CustomerId",
                table: "Bookings");

            migrationBuilder.DropColumn(
                name: "ExtraBed",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "NumberOfGuests",
                table: "Rooms");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "Rooms",
                newName: "Size");

            migrationBuilder.RenameColumn(
                name: "SizeSquareMeters",
                table: "Rooms",
                newName: "BedId");

            migrationBuilder.CreateTable(
                name: "Beds",
                columns: table => new
                {
                    BedId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BedSize = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beds", x => x.BedId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_BedId",
                table: "Rooms",
                column: "BedId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_CustomerId",
                table: "Bookings",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_RoomId",
                table: "Bookings",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Rooms_RoomId",
                table: "Bookings",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Beds_BedId",
                table: "Rooms",
                column: "BedId",
                principalTable: "Beds",
                principalColumn: "BedId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
