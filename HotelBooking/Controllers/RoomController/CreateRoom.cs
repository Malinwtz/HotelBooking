using HotelBooking.Data;
using HotelBooking.Data.Tables;

namespace HotelBooking.Controllers.RoomController;

public class CreateRoom : ICrud
{
    public CreateRoom(ApplicationDbContext dbContext)
    {
        DatabaseContext = dbContext;
    }

    public ApplicationDbContext DatabaseContext { get; set; }

    public void RunCrud()
    {
        using (var dbContext = new ApplicationDbContext())
        {
            Console.WriteLine("Registrera rum");
            Console.WriteLine("==============");
            Console.Write("SizeSquareMeters: ");
            var sizeInput = Convert.ToInt32(Console.ReadLine());
            Console.Write("Max antal gäster som får plats: ");
            var numberOfGuestsInput = Convert.ToInt32(Console.ReadLine());
            Console.Write("Bed: ");
            var bedInput = Console.ReadLine();
            //Enum.TryParse(bedInput, out Enum bedInputEnum);
            Console.Write("Typ av rum: ");
            var typeInput = Console.ReadLine();
            Console.Write("Hur många extra sängar kan ställas in: ");
            var extraBedInput = Convert.ToInt32(Console.ReadLine());

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