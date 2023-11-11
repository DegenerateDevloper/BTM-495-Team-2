public class SupplierPurchaseOrder
{
    public int supplier_purchase_order_ID { get; set; }
    public bool purchase_orders_received { get; set; }
    public DateTime purchase_order_date { get; set; }
    public List<Product> products { get; set; }

    public bool checkPurchaseOrdersReceived() 
    {
        // Logic to come
    }

    public void addProduct(int product_ID)
    {
        // Logic to come
    }
}