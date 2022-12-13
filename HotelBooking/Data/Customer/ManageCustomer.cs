namespace HotelBooking.CustomerHandler;

public class ManageCustomer
{
    public void SaveCustomerToList(Customer customer)
    {
        CustomerController controller = new CustomerController();
        controller.GetList().Add(customer);
    }

    public void SaveCustomerToDatabase()
    {

        CustomerController controller = new CustomerController();
        foreach (var VARIABLE in controller.GetList().ToString())
        {
            Console.WriteLine(VARIABLE);
        }          ///skriver ut System. ..... 

        //skicka in till DATABAS
    }
}