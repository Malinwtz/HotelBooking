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
            Console.Clear();
            Console.WriteLine("Registrera rum");
            Console.WriteLine("==============" + Environment.NewLine);
            Console.Write("SizeSquareMeters: ");
            var sizeInput = Convert.ToInt32(Console.ReadLine());
            Console.Write("Max antal gäster som får plats: ");
            var numberOfGuestsInput = Convert.ToInt32(Console.ReadLine());
            Console.Write("Typ av rum: ");
            var typeInput = Console.ReadLine();

            var extraBedInput = false;

            if (typeInput.ToLower() == "double" && sizeInput > 20) 
                extraBedInput = true;
            

            dbContext.Rooms.Add(new Room
            {
                SizeSquareMeters = sizeInput,
                NumberOfGuests = numberOfGuestsInput,
                Type = typeInput,
                ExtraBed = extraBedInput
            });
            dbContext.SaveChanges();
        }
    }
}