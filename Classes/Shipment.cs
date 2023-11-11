public class Shipment
{
    public int shipment_ID { get; set; }
    public decimal shipment_cost { get; set; }
    public string shipment_date { get; set; }
    public string shipment_status { get; set; }
    public string shipment_type { get; set; }
    public List<DeliveryMethod> delivery_method { get; set; }
    public ShoppingCart shopping_cart { get; set; }

}