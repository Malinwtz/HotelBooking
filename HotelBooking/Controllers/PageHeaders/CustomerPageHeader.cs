using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Controllers.PageHeaders
{
    public class CustomerPageHeader //: IPageHeader
    {
        public static void CreateCustomerHeader()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t\tSKAPA NY BOKNING");
            PageHeader.LineThree();
        }
        public static void ReadCustomerHeader()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t\tALLA BOKNINGAR");
            PageHeader.LineThree();
        }
        public static void UpdateCustomerHeader()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t\tÄNDRA BOKNING");
            PageHeader.LineThree();
        }
        public static void DeleteCustomerHeader()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t\tTA BORT BOKNING");
            PageHeader.LineThree();
        }
    }
}
