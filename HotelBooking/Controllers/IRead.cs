﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Controllers
{
    public interface IRead : ICrud
    {
        void View();
    }
}