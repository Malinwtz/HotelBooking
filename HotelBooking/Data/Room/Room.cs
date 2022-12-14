using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.RoomHandler
{
    public class Room
    {
        public int RoomId { get; set; }
        public int Size { get; set; }
        public int NumberOfGuests { get; set; }
        public string Type { get; set; } = "";
        public int ExtraBed { get; set; }
    }
}
