using HotelBooking.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HotelBooking.Controllers;

public class Builder
{
    public IConfigurationRoot config { get; set; }

    public void BuildProject()
    {
        var builder = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", true, true);
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

            var dbContextReturned = new ApplicationDbContext(options.Options);
            return dbContextReturned;
        }
    }
}