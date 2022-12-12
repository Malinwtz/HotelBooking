﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBooking.CustomerHandler;
using HotelBooking.RoomHandler;

namespace HotelBooking.Data
{
    public class Booking
    {
        public int BookingId { get; set; }
        public int CustomerId { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}