using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBooking.Data;

namespace HotelBooking.Controllers
{
    public class UpdateCustomer : ICrud
    {
        public ApplicationDbContext DatabaseContext { get; set; }

        public UpdateCustomer(ApplicationDbContext dbContext)
        {
            DatabaseContext = dbContext;
        }
        public void RunCrud()
        {
            
        }
    }
}
