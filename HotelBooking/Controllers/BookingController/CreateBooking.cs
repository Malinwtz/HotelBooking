﻿using HotelBooking.Controllers.BookingController;
using HotelBooking.Controllers.Interface;
using HotelBooking.Controllers.PageHeaders;
using HotelBooking.Data;
using HotelBooking.Data.Tables;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Controllers.CustomerController;

public class CreateBooking : ICrud
{
    public CreateBooking(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }
    public ApplicationDbContext DbContext { get; set; }
    public void RunCrud()
    {
        BookingPageHeader.CreateBookingHeader();
        var bookingMethod = new BookingMethod(DbContext);
        var bookingToCreate = new Booking();
        bookingToCreate.NumberOfDays = bookingMethod.GetNumberOfDays();
        bookingMethod.GetStartDate(bookingToCreate);
        bookingMethod.SetEndDate(bookingToCreate);
        var listOfBookings = new BookingList();
        bookingMethod.AddAllNewBookingDatesToList(bookingToCreate, listOfBookings);
        List<Room> availableRoom = new List<Room>();
        bookingMethod.MakeListOfRoomsFreeForBooking(listOfBookings, availableRoom);
        ShowSelectedBookingOptions(bookingToCreate);
        bookingMethod.IfRoomIsAvailable(availableRoom);
        bookingMethod.SelectRoomFromListOfAvailableRooms(bookingToCreate,  DbContext);
        bookingMethod.AssignRoomToCustomer(bookingToCreate, DbContext);
        bookingMethod.SaveBookingToDatabase(bookingToCreate);
        bookingMethod.SuccessfulBooking(bookingToCreate, "genomförd");
    }

    public void ShowSelectedBookingOptions(Booking booking)
    {
        Console.Clear();
        BookingPageHeader.CreateBookingHeader();
        BookingMethod method = new BookingMethod(DbContext);
        Console.WriteLine("\n\n\t\t\t\t\t\tDina bokningsuppgifter");
        PageHeader.LineTwo();
        Console.WriteLine($" Startdatum    Slutdatum\tAntal dagar\n{ method.Line1}" + //antal gäster
                          $"\n{booking.StartDate.ToString("dd MM yyyy")} " +
                          $"- {booking.EndDate.ToString("dd MM yyyy")} " +
                          $"\t{booking.NumberOfDays}");
    }
}