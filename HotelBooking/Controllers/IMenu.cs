using HotelBooking.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Controllers
{
    public interface IMenu
    {
        int ShowAndReturnSelection();
        void LoopMenu(int selectionMenu, ApplicationDbContext dbContext);
    }
}
