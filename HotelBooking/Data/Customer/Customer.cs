using System.ComponentModel.DataAnnotations;
using HotelBooking.Data;

namespace HotelBooking.CustomerHandler;

public class Customer
{
    public int CustomerId { get; set; }
    [Required][MaxLength(100)] public string FirstName { get; set; }
    [Required][MaxLength(100)]public string LastName { get; set; }
    [Required]public int Phone { get; set; }
    public Booking Booking { get; set; }

    //public Customer(string firstName, string lastName, int phone)
    //{
    //    FirstName = firstName;
    //    LastName = lastName;
    //    Phone = phone;
    //}
}