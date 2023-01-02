using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBooking.Data.Tables;

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

        public static void SuccessfulAction(string text)
        {
            Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($" {text}");
                Console.ForegroundColor = ConsoleColor.Gray;
                PressEnterToContinue();
        }
        public static void NotSuccessfulAction(string text)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.Gray;
            PressEnterToContinue();
        }
    }
}


