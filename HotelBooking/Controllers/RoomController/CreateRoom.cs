using HotelBooking.Controllers.Interface;
using HotelBooking.Data;
using HotelBooking.Data.Tables;

namespace HotelBooking.Controllers.RoomController;

public class CreateRoom : ICrud
{
    public CreateRoom(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public ApplicationDbContext DbContext { get; set; }

    public void RunCrud()
    {
        using (var dbContext = new ApplicationDbContext())
        {
            Room newRoom = new Room();

            Console.Clear();
            Console.WriteLine("Registrera rum");
            Console.WriteLine("==============" + Environment.NewLine);

            Console.Write("SizeSquareMeters: ");
            var sizeInput = Convert.ToInt32(Console.ReadLine());
            newRoom.SizeSquareMeters = sizeInput;

            Console.Write("Max antal gäster som får plats: ");
            var numberOfGuestsInput = Convert.ToInt32(Console.ReadLine());
            newRoom.NumberOfGuests = numberOfGuestsInput;

            Console.Write("Typ av rum: ");
            var typeInput = Console.ReadLine();
            newRoom.Type = typeInput;

            if (typeInput.ToLower() == "double" && sizeInput > 20) 
                newRoom.ExtraBed = 1;

            dbContext.Rooms.Add(newRoom);
            dbContext.SaveChanges();
        }
    }
}