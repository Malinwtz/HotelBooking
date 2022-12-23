using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Controllers
{
    public static class StringToWrite
    {
        public const string Single = "Single";
        public const string Double = "Double";

        public static void PressEnterToContinue()
        {
            Console.Write("\n Tryck på enter för att fortsätta...");
            Console.ReadKey();
        }
    }
}
