using HotelBooking.Controllers.ErrorController;
using HotelBooking.Controllers.Interface;
using HotelBooking.Controllers.PageHeaders;
using HotelBooking.Data;
using HotelBooking.Data.Tables;

namespace HotelBooking.Controllers.CustomerController;

public class UpdateCustomer : ICrud
{
    public UpdateCustomer(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public ApplicationDbContext DbContext { get; set; }
    public void RunCrud()
    {
        CustomerPageHeader.UpdateCustomerHeader();
        if (!DbContext.Customers.Any())
        {
            Console.WriteLine(" Det finns inga kunder");
        }
        else if (DbContext.Customers.Any())
        {
            var read = new ReadCustomer(DbContext);
            read.View();
            CustomerService service = new CustomerService(DbContext);
            var personToUpdate = service.FindCustomerById();

            var selectionFromUpdateCustomerMenu = CustomerMenu.UpdateCustomerMenuShowAndReturnSelection();
            Console.Clear();
            switch (selectionFromUpdateCustomerMenu)
            {
                case 1:
                {
                    service.SetCustomerFirstName(personToUpdate);
                    DbContext.SaveChanges();
                    break;
                }
                case 2:
                {
                    service.SetCustomerLastName(personToUpdate);
                    DbContext.SaveChanges();
                    break;
                }
                case 3:
                {
                    service.SetCustomerPhoneNumber(personToUpdate);
                    DbContext.SaveChanges();
                    break;
                }
            }
            StringToWrite.SuccessfulAction(" Kund ändrad!");
        }
    }
}