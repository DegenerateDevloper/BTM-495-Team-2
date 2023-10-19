public class CustomerPurchaseOrder
{
    private int customer_purchase_order_ID;
    private Customer customer;
    private string order_status;
    private DateTime order_date;
    private Shipment shipment;
    private decimal order_total;
    private Product product;
    private Payment payment;

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