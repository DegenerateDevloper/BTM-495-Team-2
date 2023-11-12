public class Payment
{
    private int payment_ID;
    private CustomerPurchaseOrder customer_purchase_order_ID;
    private CustomerPurchaseOrder order_total;
    private PaymentMethod payment_details;
    private List<Receipt> receipts;
    private string payment_status;

    public int payment_ID
    {
        get {return payment_ID;}
        set {payment_ID = value;}
    }
    public string payment_status
    {
        get {return payment_status;}
        set {payment_status = value;}
    }
    public int customer_purchase_order_ID
    {
        get {return customer_purchase_order_ID;}
    }
    public CustomerPurchaseOrder order_total;
    {
        get {return order_total;}
    }

    public string processPayment()
    {
        string cleanedNumber = new string(creditCardNumber.Where(char.IsDigit).ToArray());
        if (cleanedNumber.Length != 16 && string.IsNullOrEmpty(this.payment_details.card_number))
        {
            this.payment_status =  'Invalid Credit Card';
        }
        else 
        {
            //Charge credit card based on 
            this.payment_status = 'Successful';
        }
        return this.payment_status;
    }
}