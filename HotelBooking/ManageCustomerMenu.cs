namespace HotelBooking;

public class ManageCustomerMenu
{
    public static void CustomerMenu(int selection)
    {
        if (selection == 0)
        {
            //avsluta
        }
        else if (selection == 1)
        {
            ManageCustomer manage = new ManageCustomer();
            var customer = manage.CreateCustomer();
            manage.SaveCustomerToList(customer);
            manage.SaveCustomerToDatabase();
        }
        else if (selection == 2)
        {
            //ändra kunduppgifter
        }
        else if (selection == 3)
        {
            //avregistrera kund
        }
    }
}