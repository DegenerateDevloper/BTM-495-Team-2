public class Customer : User
{
    private string customer_email;
    private string customer_address;
    private string customer_password;
    private List<Product> customer_cart;
    private bool customer_is_confirmed;

    public string customer_email
    {
        get { return customer_email; }
        set { customer_email = value; }
    }

    public string customer_address
    {
        get { return customer_address; }
        set { customer_address = value; }
    }

    public string customer_password
    {
        get { return customer_password; }
        set { customer_password = value; }
    }

    public List<Product> CustomerCart
    {
        get { return customer_cart; }
    }

    public bool CustomerIsConfirmed
    {
        get { return customer_is_confirmed; }
        set { customer_is_confirmed = value; }
    }
    public void SendConfirmationEmail()
    {
        Console.WriteLine("Confirmation email sent to: " + customer_email);
    }
}
