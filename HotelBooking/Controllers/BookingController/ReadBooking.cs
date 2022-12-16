﻿using HotelBooking.Controllers.Interface;
using HotelBooking.Data;

namespace HotelBooking.Controllers.CustomerController;

public class ReadBooking : ICrud
{
    public ReadBooking(ApplicationDbContext dbContext) //skicka in dbcontext i ctor eller in run metod?
    {
        DbContext = dbContext;
    }

    public ApplicationDbContext DbContext { get; set; }

    public void RunCrud()
    {
        Console.Clear();
        Console.WriteLine("Visa alla bokningar");
        Console.WriteLine("================" + Environment.NewLine);
        View();
        Console.WriteLine(Environment.NewLine + "Tryck på enter för att fortsätta");
        Console.ReadKey();
    }

    public void View()
    {
        if (DbContext.Bookings == null)
            Console.WriteLine("Det finns inga bokningar");
        foreach (var booking in DbContext.Bookings)
            Console.WriteLine(
                $"Id{booking.CustomerId}: {booking.Customer} {booking.Room}");
    }
}