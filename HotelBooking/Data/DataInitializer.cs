using HotelBooking.Controllers;
using HotelBooking.Data.Tables;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Data;

public class DataInitializer
{
    public void MigrateAndSeed(ApplicationDbContext dbContext)
    {
        dbContext.Database.Migrate();
        SeedRoom(dbContext);
        SeedCustomer(dbContext);
        dbContext.SaveChanges();
    }

    private void SeedCustomer(ApplicationDbContext dbContext)
    {
        if (!dbContext.Customers.Any(c => c.Active == true))
        {
            dbContext.Customers.Add(new Customer
            {
                FirstName = "Anna",
                LastName = "Asp",
                Phone = "0707230489",
                Active = true
            });

            dbContext.Customers.Add(new Customer
            {
                FirstName = "Camilla",
                LastName = "Gustafsson",
                Phone = "0707230482",
                Active = true
            });

            dbContext.Customers.Add(new Customer
            {
                FirstName = "Ingrid",
                LastName = "Arvidsson",
                Phone = "0707230481",
                Active = true
            });

            dbContext.Customers.Add(new Customer
            {
                FirstName = "Björn",
                LastName = "Arvidsson",
                Phone = "0707230485",
                Active = true
            });

            dbContext.Customers.Add(new Customer
            {
                FirstName = "Lillemor",
                LastName = "Hammarlind",
                Phone = "0707230487",
                Active = true
            });
        }
    }

    private void SeedRoom(ApplicationDbContext dbContext)
    {
        if (!dbContext.Rooms.Any())
        {
            dbContext.Rooms.Add(new Room
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