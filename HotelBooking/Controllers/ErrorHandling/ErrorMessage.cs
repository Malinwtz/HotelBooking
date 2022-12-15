using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace HotelBooking.Controllers.ErrorHandling
{
    public class ErrorMessage
    {
        public static void WrongInputMessage()
        {
            Console.WriteLine("Felaktig input");
        }
    }
}
