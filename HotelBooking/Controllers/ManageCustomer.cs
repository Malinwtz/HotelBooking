using HotelBooking.Data.Tables;

namespace HotelBooking.Controllers;

public class ManageCustomer
{
    //public Customer CreateCustomer()
    //{
    //    //SKRIV IN KUND
    //    Console.Write("Förnamn: ");
    //    var firstName = Console.ReadLine();
    //    Console.Write("Efternamn: ");
    //    var lastName = Console.ReadLine();
    //    Console.Write("Telefonnummer:");
    //    var phone = Convert.ToInt32(Console.ReadLine());
    //    //GENERERA ID till kund - egen metod?
    //    //CREATE CUSTOMER
    //    var customer = new Customer(firstName, lastName, phone);
    //    return customer;
    //}

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