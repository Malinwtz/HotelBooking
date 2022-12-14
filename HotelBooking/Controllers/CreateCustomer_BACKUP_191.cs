using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using HotelBooking.CustomerHandler;
using HotelBooking.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Controllers
{
    public class CreateCustomer : ICrud
    {
        public ApplicationDbContext DatabaseContext { get; set; }

        public CreateCustomer(ApplicationDbContext dbContext)
        {
            DatabaseContext = dbContext;
        }
        public void RunCrud()
        {
            using (var dbContext = new ApplicationDbContext())
            {
                Console.WriteLine("Registrera ny kund");
                Console.WriteLine("==================");
                Console.Write("Förnamn: ");
                var firstNameInput = Console.ReadLine();
                Console.Write("Efternamn: ");
                var lastNameInput = Console.ReadLine();
                Console.Write("Telefon: ");
                var phoneInput = Convert.ToInt32(Console.ReadLine());

                dbContext.Customers.Add(new Customer
                {
                    FirstName = firstNameInput,
                    LastName = lastNameInput,
                    Phone = phoneInput
                });
                dbContext.SaveChanges();
            }
        }
    }
}
