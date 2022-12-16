using HotelBooking.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Controllers
{

    public interface ICrud
    {
        public ApplicationDbContext DbContext { get; set; }
        public void RunCrud();
    }
}
