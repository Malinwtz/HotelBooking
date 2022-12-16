using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBooking.Data;
using Microsoft.Extensions.Options;

namespace HotelBooking.Controllers.CustomerController
{
    public class DeleteCustomer : ICrud
    {
        public ApplicationDbContext DatabaseContext { get; set; }

        public DeleteCustomer(ApplicationDbContext dbContext)
        {
            DatabaseContext = dbContext;
        }
        public void RunCrud()
        {
            using (DatabaseContext)
            {
                Console.WriteLine("Ta bort en kund");
                Console.WriteLine("===============");

                foreach (var customer in DatabaseContext.Customers)
                {
                    Console.WriteLine($"Id: {customer.CustomerId}, {customer.FirstName} {customer.LastName}");
                }

                Console.WriteLine("Välj Id på den kund som du vill ta bort");
                var customerIdToDelete = Convert.ToInt32(Console.ReadLine());
                var customerToDelete = DatabaseContext.Customers.First(p => p.CustomerId == customerIdToDelete);
                DatabaseContext.Customers.Remove(customerToDelete);//ändra till soft delete

                DatabaseContext.SaveChanges();
            }
        }
    }
}
