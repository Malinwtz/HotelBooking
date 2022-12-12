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
                var customer = new Customer(firstName, lastName, phone);

             //   dbContext.Customer.Add(customer);
                dbContext.SaveChanges();
            }
        }
    }
}
