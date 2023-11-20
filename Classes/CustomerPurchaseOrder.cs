public class CustomerPurchaseOrder
{
    private int customer_purchase_order_ID;
    private Customer customer;
    private string order_status;
    private DateTime order_date;
    private Shipment shipment;
    private ShoppingCart order_total;
    private decimal order_total_with_tax;
    private decimal refund_amount;
    private bool isReturn;
    private bool isExchange;
    private List<Product> products = new List<Product>();
    private Payment pmethod_ID;

    public int customer_purchase_order_ID
    {
        get {return customer_purchase_order_ID;}
        set {customer_purchase_order_ID = value;}
    }
    public bool isReturn
    {
        get {return isReturn;}
        set {isReturn = value;}    
    }

    private decimal refund_amount
    {
        get {return refund_amount;}
        set {refund_amount = value;}    
    }
    public bool isExchange
    {
        get {return isExchange;}
        set {isExchange = value;}    
    }
    private Customer customer
    {
        get {return customer;}
    }

    private string order_status
    {
        get {return order_status;}
        set {order_status = value;}
    }
    private DateTime order_date
    {
        get {return order_date;}
        set {order_date = value;}   
    }
    private Shipment shipment
    {        
        get {return shipment;}
    }
    private ShoppingCart order_total
    {
        get {return order_total;}
    }

    public void returnOrderProducts() 
    {
        if (isReturn)
        {
        InventoryDatabase.storeInventoryItem();
        calculateOrderTotalWithTax();
        Payment.processPayment();
        }
    }

    public decimal calculateOrderTotalWithTax() 
    {
        order_total_with_tax = 1.15 * order_total;
        return order_total_with_tax;
    }

    public void exchangeOrder() 
    {
        if (isExchange)
        {
            products.Remove(products);
            products.add(products;)
            InventoryDatabase.storeInventoryItem();
        }
    }
}