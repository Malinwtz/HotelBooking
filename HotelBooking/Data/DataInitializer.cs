using HotelBooking.Data.Tables;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Data
{
    public class DataInitializer
    {
        public DataInitializer() { }
        public void MigrateAndSeed(ApplicationDbContext dbContext)
        {
            dbContext.Database.Migrate();
            SeedRoom(dbContext);
            SeedCustomer(dbContext);
            dbContext.SaveChanges();
        }
        private void SeedCustomer(ApplicationDbContext dbContext)
        {
            if (!dbContext.Customers.Any(c => c.FirstName == "Annie" && c.LastName == "Sörensen"))
            {
                dbContext.Customers.Add(new Customer
                {
                    FirstName = "Annie",
                    LastName = "Sörensen",
                    Phone = 0707230489
                });
            }
            if (!dbContext.Customers.Any(c => c.FirstName == "Frida" && c.LastName == "Jönsson"))
            {
                dbContext.Customers.Add(new Customer
                {
                    FirstName = "Frida",
                    LastName = "Jönsson",
                    Phone = 0707230482
                });
            }
            if (!dbContext.Customers.Any(c => c.FirstName == "Håkan" && c.LastName == "Elofsson"))
            {
                dbContext.Customers.Add(new Customer
                {
                    FirstName = "Håkan",
                    LastName = "Elofsson",
                    Phone = 0707230481
                });
            }
            if (!dbContext.Customers.Any(c => c.FirstName == "Erik" && c.LastName == "Holm"))
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
            if (!dbContext.Rooms.Any(c => c.RoomId == 1))
            {
                dbContext.Rooms.Add(new Room()
                {
                    SizeSquareMeters = 20,
                    NumberOfGuests = 2,
                    ExtraBed = 1,
                    Type = "Single"
                });
            }
            if (!dbContext.Rooms.Any(c => c.RoomId == 2))
            {
                dbContext.Rooms.Add(new Room
                {
                    SizeSquareMeters = 30,
                    NumberOfGuests = 3,
                    ExtraBed = 1,
                    Type = "Double"
                });
            }
            if (!dbContext.Rooms.Any(c => c.RoomId == 3))
            {
                dbContext.Rooms.Add(new Room
                {
                    SizeSquareMeters = 40,
                    NumberOfGuests = 4,
                    ExtraBed = 2,
                    Type = "Double"
                });
            }
            if (!dbContext.Rooms.Any(c => c.RoomId == 4))
            {
                dbContext.Rooms.Add(new Room
                {
                    SizeSquareMeters = 50,
                    NumberOfGuests = 4,
                    ExtraBed = 2,
                    Type = "Single"
                });
            }
        }
    }
}