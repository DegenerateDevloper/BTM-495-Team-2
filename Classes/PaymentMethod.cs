public class PaymentMethod
{
    private int pmethod_ID;
    private string pmethod_type;
    private int cvc_code;
    private int card_number;
    private string cardholder_name;
    private DateTime expiration_date;
    private List<Customer> customers;

    public PaymentMethod(pmethod_type string, cvc_code int, card_number int, cardholder_name string, expiration_date DateTime)
    {
        this,pmethod_type = pmethod_type;
        this.cvc_code = cvc_code;
        this.card_number = card_number;
        this.cardholder_name = cardholder_name;
        this.expiration_date = expiration_date;
    }
     public int pmethod_ID
    {
        get { return pmethod_ID; }
        set { pmethod_ID = value; }
    }

    public string pmethod_type
    {
        get { return pmethod_type; }
        set { pmethod_type = value; }
    }

    public int cvc_code
    {
        get { return cvc_code; }
        set { cvc_code = value; }
    }

    public int card_number
    {
        get { return card_number; }
        set { card_number = value; }
    }

    public string cardholder_name
    {
        get { return cardholder_name; }
        set { cardholder_name = value; }
    }

    public DateTime expiration_date
    {
        get { return expiration_date; }
        set { expiration_date = value; }
    }

    public PaymentMethod()
    {
        customers = new List<Customer>();
    }

    public List<Customer> customers
    {
        get {return customers;}
    }

    public void addCustomer(Customer customer)
    {
        customers.add(customer);
    }

    public void sendCreditCardInformation() 
    {
        // Logic to come
    }

}