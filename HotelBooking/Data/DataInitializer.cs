﻿using HotelBooking.Data.Tables;
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
            if (!dbContext.Customers.Any(c => c.FirstName == firstName1 && c.LastName == lastName1))
            {
                dbContext.Customers.Add(new Customer
                {
                    FirstName = firstName1,
                    LastName = lastName1,
                    Phone = 0707230489
                });
            }

            var firstName2 = "Carina";
            var lastName2 = "Löv";
            if (!dbContext.Customers.Any(c => c.FirstName == firstName2 && c.LastName == lastName2))
            {
                dbContext.Customers.Add(new Customer
                {
                    FirstName = firstName2,
                    LastName = lastName2,
                    Phone = 0707230482
                });
            }

            var firstName3 = "Håkan";
            var lastName3 = "Holmström";
            if (!dbContext.Customers.Any(c => c.FirstName == firstName3 && c.LastName == lastName3))
            {
                dbContext.Customers.Add(new Customer
                {
                    FirstName = firstName3,
                    LastName = lastName3,
                    Phone = 0707230481
                });
            }

            var firstName4 = "Håkan";
            var lastName4 = "Holmström";
            if (!dbContext.Customers.Any(c => c.FirstName == firstName4 && c.LastName == lastName4))
            {
                dbContext.Customers.Add(new Customer
                {
                    FirstName = firstName4,
                    LastName = lastName4,
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
                    SizeSquareMeters = 15,
                    NumberOfGuests = 1,
                    ExtraBed = false,
                    Type = "Single"
                });
            }
            if (!dbContext.Rooms.Any(c => c.RoomId == 2))
            {
                dbContext.Rooms.Add(new Room
                {
                    SizeSquareMeters = 20,
                    NumberOfGuests = 2,
                    ExtraBed = true,
                    Type = "Double"
                });
            }
            if (!dbContext.Rooms.Any(c => c.RoomId == 3))
            {
                dbContext.Rooms.Add(new Room
                {
                    SizeSquareMeters = 40,
                    NumberOfGuests = 4,
                    ExtraBed = true,
                    Type = "Double"
                });
            }
            if (!dbContext.Rooms.Any(c => c.RoomId == 4))
            {
                dbContext.Rooms.Add(new Room
                {
                    SizeSquareMeters = 50,
                    NumberOfGuests = 4,
                    ExtraBed = true,
                    Type = "Double"
                });
            }
        }
    }
}