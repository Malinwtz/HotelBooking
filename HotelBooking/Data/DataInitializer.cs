using HotelBooking.Controllers;
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
            var firstName1 = "Anna";
            var lastName1 = "Ek";
            if (!dbContext.Customers.Any(c=>c.Active == true))
            {
                dbContext.Customers.Add(new Customer
                {
                    FirstName = firstName1,
                    LastName = lastName1,
                    Phone = "0707230489",
                    Active = true
                });
            

                var firstName2 = "Ella";
                var lastName2 = "Löv";
            
                dbContext.Customers.Add(new Customer
                {
                    FirstName = firstName2,
                    LastName = lastName2,
                    Phone = "0707230482",
                    Active = true
                });
            

                var firstName3 = "Håkan";
                var lastName3 = "Alm";
            
                dbContext.Customers.Add(new Customer
                {
                    FirstName = firstName3,
                    LastName = lastName3,
                    Phone = "0707230481",
                    Active = true
                });

                var firstName4 = "Per";
                var lastName4 = "Björk";
            
                dbContext.Customers.Add(new Customer
                {
                    FirstName = firstName4,
                    LastName = lastName4,
                    Phone = "0707230485",
                    Active = true
                });
            }
        }

        private void SeedRoom(ApplicationDbContext dbContext)
        {
            if (!dbContext.Rooms.Any())
            {
                dbContext.Rooms.Add(new Room()
                {
                    SizeSquareMeters = 15,
                    NumberOfGuests = 1,
                    ExtraBed = 0,
                    Type = StringToWrite.Single
                });
           
                dbContext.Rooms.Add(new Room
                {
                    SizeSquareMeters = 20,
                    NumberOfGuests = 2,
                    ExtraBed = 0,
                    Type = StringToWrite.Double
                });
            
                dbContext.Rooms.Add(new Room
                {
                    SizeSquareMeters = 30,
                    NumberOfGuests = 3,
                    ExtraBed = 1,
                    Type = StringToWrite.Double
                });
           
                dbContext.Rooms.Add(new Room
                {
                    SizeSquareMeters = 40,
                    NumberOfGuests = 4,
                    ExtraBed = 2,
                    Type = StringToWrite.Double
                });
            }
        }
    }
}