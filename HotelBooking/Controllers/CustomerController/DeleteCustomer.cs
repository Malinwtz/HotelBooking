using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBooking.Controllers.ErrorController;
using HotelBooking.Controllers.Interface;
using HotelBooking.Controllers.PageHeaders;
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

            Console.Clear();
            Console.WriteLine(" TA BORT KUND");
            PageHeader.LineOne();

                foreach (var customer in DbContext.Customers)
                {
                    Console.WriteLine($" Id: {customer.CustomerId}, {customer.FirstName} {customer.LastName}");
                }

                Console.WriteLine("\n Välj Id på den kund som du vill ta bort");
                var customerIdToDelete = ErrorHandling.TryInt();
                var customerToDelete = DbContext.Customers
                    .FirstOrDefault(c => c.CustomerId == customerIdToDelete);

            //om kunden har en bokning ska det inte gå att ta bort kunden
            if (customerToDelete.Bookings != null ) //object not set to an instance
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Det går inte att ta bort kunden eftersom kunden har en aktiv bokning");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else if (customerToDelete.Bookings == null)
            {
                customerToDelete.Active = false;
               /// DbContext.Customers.Remove(customerToDelete);//ändra till soft delete
                DbContext.SaveChanges();
            }
        }
    }
}