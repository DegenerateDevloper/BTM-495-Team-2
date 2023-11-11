public class Customer : User
{
	private string customer_email;
	private string customer_address;
	private string customer_password;
	private List<Product> customer_cart;
	private bool customer_is_confirmed;
	private PaymentMethod payment_information;

	public Customer()
    {

    }

	public void sendConfirmationEmail()
 	{
		//Logic to come
	}

}