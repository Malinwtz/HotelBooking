using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Data.Tables
{
    public class Room
    {
        public int RoomId { get; set; }
        public int Size { get; set; }
        public int NumberOfGuests { get; set; }
        public string Type { get; set; }
        public int ExtraBed { get; set; }
        public List<Booking> Bookings { get; set; }

    }
}
