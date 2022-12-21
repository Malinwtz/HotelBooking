using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Controllers.PageHeaders
{
    public class RoomPageHeader
    {
        public static void CreateRoomHeader()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t\tSKAPA NY BOKNING");
            PageHeader.LineThree();
        }

        public static void ReadRoomHeader()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t\tALLA BOKNINGAR");
            PageHeader.LineThree();
        }

        public static void UpdateRoomHeader()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t\tÄNDRA BOKNING");
            PageHeader.LineThree();
        }

        public static void DeleteRoomHeader()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t\tTA BORT BOKNING");
            PageHeader.LineThree();
        }
    }
}
