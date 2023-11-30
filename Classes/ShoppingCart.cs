public class ShoppingCart
{
    private int shopping_cart_ID;
    private List<Product> products_in_sc = new List<Product>();
    private int customerID;
    public decimal total_price;

    public ShoppingCart(List<Product> products, int customerID, decimal total)
    {
        this.products_in_sc = products;
        this.customerID = customerID;
        this.total_price = total;
    }

    public int shopping_cart_ID
    {
        get {return shopping_cart_ID;}
        set {shopping_cart_ID = value;}
    }
    public decimal total_price
    {
        get {return total_price;}
        set {total_price = value;}
    }
    public List<Product> products_in_sc
    {
        get {return products_in_sc;}
    } 

    public void addToShoppingCart(int product_ID) 
    {
        products_in_sc.Add(products_in_sc);
        calculateTotalPrice();
    }
    
    public void deleteFromShoppingCart(int product_ID) 
    {
        products_in_sc.Remove(products_in_sc);
        calculateTotalPrice();
    }

    private void calculateTotalPriceWithoutTax()
    {
        decimal TotalPrice = 0;
        foreach (var Product in products_in_sc)
        {
            TotalPrice += Product.product_price;
        }
        total_price = TotalPrice;
    }
}