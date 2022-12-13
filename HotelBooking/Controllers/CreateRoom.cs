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
                var sizeInput = Console.ReadLine();
                Console.Write("Bed: ");
                var bedInput = Console.ReadLine();
                Enum.TryParse(bedInput, out Enum bedInputEnum);

                var room = new Room(sizeInput, bedInputEnum);

                dbContext.Customers.Add(room);
                dbContext.SaveChanges();
            }
        }
    }
}
