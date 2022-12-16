using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBooking.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace HotelBooking.Controllers
{
    public class Builder
    {
        public IConfigurationRoot config { get; set; }
        public void BuildProject()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json", true, true);
            config = builder.Build();
        }

        public ApplicationDbContext ConnectProject()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = config.GetConnectionString("DefaultConnection");
            options.UseSqlServer(connectionString);

            using (var dbContext = new ApplicationDbContext(options.Options))
            {
                var dataInitiaizer = new DataInitializer();
                dataInitiaizer.MigrateAndSeed(dbContext);
                return dbContext;
            }
        }


        //public void CreateOrCheckIfDatabaseExists()
        //{
        //    using (var dbContext = new ApplicationDbContext(options.Options))
        //    {
        //        var dataInitiaizer = new DataInitializer();
        //        dataInitiaizer.MigrateAndSeed(dbContext);
        //    }
        //}
    }
}
