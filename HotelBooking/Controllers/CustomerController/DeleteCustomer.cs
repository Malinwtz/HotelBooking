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
        public ApplicationDbContext DbContext { get; set; }

        public DeleteCustomer(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public void RunCrud()
        {
            using (DbContext)
            {
                Console.WriteLine("Ta bort en kund");
                Console.WriteLine("===============");

                foreach (var customer in DbContext.Customers)
                {
                    Console.WriteLine($"Id: {customer.CustomerId}, {customer.FirstName} {customer.LastName}");
                }

                Console.WriteLine("Välj Id på den kund som du vill ta bort");
                var customerIdToDelete = Convert.ToInt32(Console.ReadLine());
                var customerToDelete = DbContext.Customers.First(p => p.CustomerId == customerIdToDelete);
                DbContext.Customers.Remove(customerToDelete);//ändra till soft delete

                DbContext.SaveChanges();
            }
        }
    }
}
