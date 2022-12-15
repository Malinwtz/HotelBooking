using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Controllers.Menu
{
    public interface IMenu
    {
        int ShowAndReturnSelection();
        void LoopMenu();
    }
}
