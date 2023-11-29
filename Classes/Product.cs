using System;
using System.Collections.Generic;

public class Product
{
    private int product_ID;
    private string product_name;
    private string product_description;
    private int product_number;
    private string product_type;
    private decimal product_price;
    private int sku_number;
    private List<Supplier> suppliers;
    private double product_dimension;
    private double product_weight;

    public Product(int productID, string productName, string productDescr, int productNum, string productType, decimal productPrice, int sku, List<Supplier> suppliers, double productDimension, double productWeight)
    {
        this.product_ID = productID;
        this.product_name = productName;
        this.product_description = productDescr;
        this.product_number = productNum;
        this.product_type = productType;
        this.Product_price = productPrice;
        this.sku_number = sku;
        this.suppliers = suppliers;
        this.Product_dimension = productDimension;
        this.Product_weight = productWeight;
    }

    public int Product_ID
    {
        get { return product_ID; }
        set { product_ID = value; }
    }

    public string Product_name
    {
        get { return product_name; }
        set { product_name = value; }
    }

    public string Product_description
    {
        get { return product_description; }
        set { product_description = value; }
    }

    public int Product_number
    {
        get { return product_number; }
        set { product_number = value; }
    }

    public string Product_type
    {
        get { return product_type; }
        set { product_type = value; }
    }

    public decimal Product_price
    {
        get { return product_price; }
        set { product_price = value; }
    }

    public int SKU_number
    {
        get { return sku_number; }
        set { sku_number = value; }
    }

    public List<Supplier> Suppliers
    {
        get { return suppliers; }
    }

    public double Product_dimension
    {
        get { return product_dimension; }
        set { product_dimension = value; }
    }

    public double Product_weight
    {
        get { return product_weight; }
        set { product_weight = value; }
    }

    /**
     * Retrieves product that customer has chosen, but it might not be available so it will return null
     */
    public static Product retrieveProduct(string productName)
    {
        // Retrieve the product that the customer wants
        string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Files\\product.txt";
        //Seperate the records by using the new line as a breaking point to retrieve all of them
        string[] productsInDB = File.ReadLines(path).Split(new string[] { "\n" }, StringSplitOptions.None);
        int amountProductFound = 0;
        int productID = 0;
        if (productsInDB != null || productsInDB != "")
        {
            for (int i=0; i<productsInDB.Length; i++) {
                string[] singleProduct = productsInDB[i].Split(new string[] { ": " }, StringSplitOptions.None);
                //The first index is the ID of the product
                string[] singleProductInfo = singleProduct[1].Split(new string[] { ", " }, StringSplitOptions.None);
                if (singleProductInfo[0].Equals(productName))
                {
                    //Product matches name that customer wants
                    Int32.TryParse(singleProduct[0], out productID);
                    int prodInInventory = getProductInventoryCount(productID);
                    if (prodInInventory == 0)
                    {
                        //There is no stock of the product in inventory
                        return null;
                    }
                    else
                    {
                        //The product in question is in stock
                        removeInventoryItem(singleProduct[0], 1);
                        double productNum = 0;
                        decimal productPrice = 0;
                        int sku = 0;
                        double productDimension = 0;
                        double productWeight = 0;
                        Double.TryParse(singleProductInfo[2], out productNum);
                        Decimal.TryParse(singleProductInfo[4], out productPrice);
                        Int32.TryParse(singleProductInfo[5], out sku);
                        Double.TryParse(singleProductInfo[7], out productDimension);
                        Double.TryParse(singleProductInfo[8], out productWeight);
                        List<Supplier> suppliers = new List<Supplier>(singleProductInfo[6]);
                        Product productRetrieved = new Product(productID, productName, singleProductInfo[1], productNum, singleProductInfo[3], productPrice, sku, suppliers, productDimension, productWeight);
                        return productRetrieved;
                    }
                }
                if(i+1 == productsInDB.Length)
                {
                    return null;
                }
            }
        }
    }
}