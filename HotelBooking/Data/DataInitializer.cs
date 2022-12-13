using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using HotelBooking.CustomerHandler;

namespace HotelBooking.Data
{
    public class DataInitializer
    {
        public DataInitializer() { }
        public void MigrateAndSeed(ApplicationDbContext dbContext)
        {
            dbContext.Database.Migrate(); 
            SeedRoom(dbContext); //room, guest
            SeedCustomer(dbContext);
            dbContext.SaveChanges(); 
        }

        private void SeedCustomer(ApplicationDbContext dbContext)
        {
            if (!dbContext.Customers.Any(c => c.CustomerId == 1));
            {
                dbContext.Customers.Add(new Customer
                {
                    CustomerId = 1,
                    FirstName = "Annie",
                    LastName = "Sörensen",
                    Phone = 0707230489
                });
            }
            if (!dbContext.Customers.Any(c => c.CustomerId == 2)) ;
            {
                dbContext.Customers.Add(new Customer
                {
                    CustomerId = 2,
                    FirstName = "Frida",
                    LastName = "Jönsson",
                    Phone = 0707230482
                });
            }
            if (!dbContext.Customers.Any(c => c.CustomerId == 3)) ;
            {
                dbContext.Customers.Add(new Customer
                {
                    CustomerId = 3,
                    FirstName = "Håkan",
                    LastName = "Elofsson",
                    Phone = 0707230481
                });
            }
            if (!dbContext.Customers.Any(c => c.CustomerId == 4)) ;
            {
                dbContext.Customers.Add(new Customer
                {
                    CustomerId = 4,
                    FirstName = "Erik",
                    LastName = "Holm",
                    Phone = 0707230485
                });
            }
        }

        private void SeedRoom(ApplicationDbContext dbContext)
        {

        }
    }
}