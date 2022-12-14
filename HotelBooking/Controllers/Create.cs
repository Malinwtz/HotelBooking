using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBooking.CustomerHandler;
using HotelBooking.Data;

namespace HotelBooking.Controllers
{
    public class Create
    {
        public void CreateCustomer()
        {
            using (var dbContext = new ApplicationDbContext())
            {
                Console.WriteLine("Registrera ny kund");
                Console.WriteLine("==================");
                Console.Write("Förnamn: ");
                var firstName = Console.ReadLine();
                Console.Write("Efternamn: ");
                var lastName = Console.ReadLine();
                Console.Write("Telefon: ");
                var phone = Convert.ToInt32(Console.ReadLine());
                

                dbContext.Customers.Add( new Customer
                {
                    FirstName = firstName, 
                    LastName = lastName, 
                    Phone = phone
                });
                dbContext.SaveChanges();
            }
        }
    }
}
