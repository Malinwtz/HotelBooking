using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBooking.Controllers.CRUD;

namespace HotelBooking.Controllers.Read
{
    public interface IRead : ICrud
    {
        void View();
    }
}
