public class Payment
{
    private int payment_ID;
    private CustomerPurchaseOrder customer_purchase_order_ID;
    private CustomerPurchaseOrder order_total;
    private PaymentMethod payment_details;
    private List<Receipt> receipts;

    public int payment_ID
    {
        get {return payment_ID;}
        set {payment_ID = value;}
    }
    public int customer_purchase_order_ID
    {
        get {return customer_purchase_order_ID;}
    }
    public CustomerPurchaseOrder order_total;
    {
        get {return order_total;}
    }

    public processPayment(int customer_ID,int delivery_method_type, int payment_info)
    {
        //Logic to come
    }
}