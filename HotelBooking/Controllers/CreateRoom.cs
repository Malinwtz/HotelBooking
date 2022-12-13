using HotelBooking.CustomerHandler;
using HotelBooking.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBooking.RoomHandler;

namespace HotelBooking.Controllers
{
    public class CreateRoom : ICrud
    {
        public ApplicationDbContext DatabaseContext { get; set; }

        public CreateRoom(ApplicationDbContext dbContext)
        {
            DatabaseContext = dbContext;
        }
        public void Run()
        {
            using (var dbContext = new ApplicationDbContext())
            {
                Console.WriteLine("Registrera rum");
                Console.WriteLine("==============");
                Console.Write("Size: ");
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
                    Size = sizeInput,
                    NumberOfGuests = numberOfGuestsInput,
                    Type = typeInput,
                    ExtraBed = extraBedInput
                });
                dbContext.SaveChanges();
            }
        }
    }
}
