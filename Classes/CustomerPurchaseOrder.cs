public class CustomerPurchaseOrder
{
    private int customer_purchase_order_ID;
    private Customer customer;
    private string order_status;
    private DateTime order_date;
    private Shipment shipment;
    private ShoppingCart order_total;
    private List<Product> products;
    private Payment payment;

    public int customer_purchase_order_ID
    {
        get {return customer_purchase_order_ID;}
        set {customer_purchase_order_ID = value;}
    }
    private ShoppingCart order_total
    {
        get {return order_total;}
    }

    public void returnOrderProducts() 
    {
        // Logic to come
    }

    public decimal calculateOrderTotal() 
    {
        // Logic to come
    }

    public void sendPurchaseOrder() 
    {
        // Logic to come
    }

    public void exchangeOrder() 
    {
        // Logic to come
    }

    public void selectDeliveryMethod(int method_choice) 
    {
        // Logic to come
    }
}