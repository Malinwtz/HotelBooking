using HotelBooking.Data;

namespace HotelBooking.Controllers.RoomController;

public class UpdateRoom : ICrud
{
    public UpdateRoom(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public ApplicationDbContext DbContext { get; set; }

    public void RunCrud()
    {
        using (DbContext)
        {
            Console.WriteLine("Ändra kundinformation");
            Console.WriteLine("=====================");
            foreach (var c in DbContext.Customers)
                Console.WriteLine($"{c.CustomerId}. {c.FirstName} {c.LastName}");

            Console.Write("Välj Id på den kund du vill uppdatera: ");
            var roomIdToUpdate = Convert.ToInt32(Console.ReadLine());
            var roomToUpdate = DbContext.Customers
                .First(c => c.CustomerId == roomIdToUpdate);

            Console.Write("Ange förnamn: ");
            var updatedFirstName = Console.ReadLine();
            Console.Write("Ange efternamn: ");
            var updatedLastName = Console.ReadLine();
            Console.Write("Ange telefonnummer: ");
            var updatedPhone = Convert.ToInt32(Console.ReadLine());

            roomToUpdate.FirstName = updatedFirstName;
            roomToUpdate.LastName = updatedLastName;
            roomToUpdate.Phone = updatedPhone;
            DbContext.SaveChanges();
        }
    }
}