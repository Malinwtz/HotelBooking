using HotelBooking.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Controllers
{
    public class UpdateRoom : ICrud
    {
        public ApplicationDbContext DatabaseContext { get; set; }
        public UpdateRoom(ApplicationDbContext dbContext)
        {
            DatabaseContext = dbContext;
        }
        public void RunCrud()
        {
            using (DatabaseContext)
            {
                Console.WriteLine("Ändra kundinformation");
                Console.WriteLine("=====================");
                foreach (var c in DatabaseContext.Customers)
                {
                    Console.WriteLine($"{c.CustomerId}. {c.FirstName} {c.LastName}");
                }

                Console.Write("Välj Id på den kund du vill uppdatera: ");
                var roomIdToUpdate = Convert.ToInt32(Console.ReadLine());
                var roomToUpdate = DatabaseContext.Customers
                    .First(c => c.CustomerId == roomIdToUpdate);

                Console.Write("Ange förnamn: ");
                var updatedFirstName = Console.ReadLine();
                Console.Write("Ange efternamn: ");
                var updatedLastName = Console.ReadLine();
                Console.Write("Ange telefonnummer: ");
                var updatedPhone = Convert.ToInt32(Console.ReadLine());

                roomToUpdate.FirstName = updatedFirstName;
                roomToUpdate.LastName = updatedLastName; 
                roomToUpdate.Phone = updatedPhone;
                DatabaseContext.SaveChanges();
            }
        }
    }
}
