using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using HotelBooking.Controllers.Interface;

namespace HotelBooking.Controllers.PageHeaders
{
    public class PageHeader
    {
        public static void LineOne()
        {
            Console.WriteLine(" ======================================================" +
                "=======================================================" + Environment.NewLine);
        }
        public static void LineTwo()
        {
            Console.WriteLine(" ------------------------------------------------------" + 
                 "-------------------------------------------------------" + Environment.NewLine);
        }
        public static void LineThree()
        {
            Console.WriteLine(" ******************************************************" +
                              "*******************************************************" + Environment.NewLine);
        }

        
    }

    
    
}
