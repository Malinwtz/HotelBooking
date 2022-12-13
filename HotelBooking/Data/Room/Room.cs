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
        public string Size { get; set; }
        public string Type { get; set; } //double eller single
        public Bed ExtraBed { get; set; } //konvertera till string i databas

        public enum Bed
        {
            Single,
            Double
        };
    }
}
