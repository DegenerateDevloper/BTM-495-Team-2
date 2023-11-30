using System.Collections.Generic


public class InventoryDatabase
{
	private Dictionary<string, int> inventory_products;
	public InventoryDatabase()
    {
        inventory_products = new Dictionary<int, int>();
    }
    public Dictionary<string, int> inventory_products
    {
        get {return inventory_products;}
        set {inventory_products = value;}
    }
    public void storeInventoryItem(int product_ID, int quantity) 
    {
        if (inventory_products.ContainsKey(product_ID))
        {
            inventory_products[product_ID]+= quantity;
        }
        else
        {
            inventory_products.Add(product_ID, quantity);
        }
    }

    public void removeInventoryItem(int product_ID, int quantity)
    {
        if (inventory_products.ContainsKey(product_ID))
        {
            inventory_products[product_ID] -= quantity;
        }
    }

    public int getProductInventoryCount(int product_ID) 
    {
        if (inventory_products.ContainsKey(product_ID))
        {
            return inventory_products.Count(product_ID);
        }
        else
        {
            return 0;
        }
    }
}