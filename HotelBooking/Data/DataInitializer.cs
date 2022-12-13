using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using HotelBooking.CustomerHandler;
using HotelBooking.RoomHandler;

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
                    
                    FirstName = "Annie",
                    LastName = "Sörensen",
                    Phone = 0707230489
                });
            }
            if (!dbContext.Customers.Any(c => c.CustomerId == 2)) ;
            {
                dbContext.Customers.Add(new Customer
                {
                   
                    FirstName = "Frida",
                    LastName = "Jönsson",
                    Phone = 0707230482
                });
            }
            if (!dbContext.Customers.Any(c => c.CustomerId == 3)) ;
            {
                dbContext.Customers.Add(new Customer
                {
                  
                    FirstName = "Håkan",
                    LastName = "Elofsson",
                    Phone = 0707230481
                });
            }
            if (!dbContext.Customers.Any(c => c.CustomerId == 4)) ;
            {
                dbContext.Customers.Add(new Customer
                {
                   
                    FirstName = "Erik",
                    LastName = "Holm",
                    Phone = 0707230485
                });
            }
        }

        private void SeedRoom(ApplicationDbContext dbContext)
        {
            if (!dbContext.Rooms.Any(c => c.RoomId == 1)) ;
            {
                dbContext.Rooms.Add(new Room()
                {
                    Size = 20,
                    NumberOfGuests = 1,
                    ExtraBed = 0,
                    Type = "Single"
                });
            }
            if (!dbContext.Rooms.Any(c => c.RoomId == 2)) ;
            {
                dbContext.Rooms.Add(new Room
                {
                    Size = 30,
                    NumberOfGuests = 2,
                    ExtraBed = 1,
                    Type = "Double"
                });
            }
            if (!dbContext.Rooms.Any(c => c.RoomId == 3)) ;
            {
                dbContext.Rooms.Add(new Room
                {
                    Size = 40,
                    NumberOfGuests = 3,
                    ExtraBed = 2,
                    Type = "Double"
                });
            }
            if (!dbContext.Rooms.Any(c => c.RoomId == 4)) ;
            {
                dbContext.Rooms.Add(new Room
                {
                    Size = 50,
                    NumberOfGuests = 4,
                    ExtraBed = 3,
                    Type = "Single"
                });
            }
        }
    }
}