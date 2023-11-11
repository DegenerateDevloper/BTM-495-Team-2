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
}