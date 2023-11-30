using System.Linq;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Windows;
using System.IO;
using System.Reflection;
using System;


public class Receipt
{
    public int receipt_ID { get; set; }
    public List<Product> products_bought { get; set; }
    public int customer_ID { get; set; }
    public decimal total_cost { get; set; }
    public Payment payment { get; set; }

    public Receipt(int receiptID, List<Product> productsBought, int customerID, Payment aPayment)
    {
        this.receipt_ID = receiptID;
        this.products_bought = productsBought;
        this.customer_ID = customerID;
        this.total_cost = productsBought.Sum(singleProd => singleProd.product_price);
        this.payment = aPayment;
    }

    public Receipt(List<Product> productsBought, int customerID, Payment aPayment)
    {
        // Retrieve the last receipt method from data storage and enter the last ID
        string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Files\\receipt.txt";
        string lastReceipt = File.ReadLines(path).Last();
        int lastReceiptID = 0;
        if (lastReceipt != null || lastReceipt != "")
        {
            string[] singleReceipt = lastReceipt.Split(new string[] { ": " }, StringSplitOptions.None);
            //The first index is the ID of the receipt
            Int32.TryParse(singleReceipt[0], out lastReceiptID + 1);
        }
        this.receipt_ID = lastReceiptID;
        this.products_bought = productsBought;
        this.customer_ID = customerID;
        this.total_cost = productsBought.Sum(singleProd => singleProd.product_price);
        this.payment = aPayment;
    }

    public int addAndRetrieveReceipt() 
    {
        //Enter the current receipt into data store as a matter of proof
        string insertNewReceipt = this.receipt_ID + ": " +this.customer_ID+ ", "+this.total_cost+". Products bought: ";
        for(int i=0; i<products_bought.length; i++)
        {
            if (i == products_bought.length-1)
            {
                string.Concat(insertNewReceipt, products_bought[i].product_name + ".");
            }
            else
            {
                string.Concat(insertNewReceipt, products_bought[i].product_name + ", ");
            }
        }
        string.Concat(insertNewReceipt, aPayment.payment_ID);
        StreamWriter newReceipt = new StreamWriter(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Files\\receipts.txt");
        newReceipt.WriteLine(insertNewReceipt);
        newReceipt.Close();

        emptyCustomerShoppingCart();

        return this.receipt_ID;
    }

    /**
     * Retrieve the customer's info to empty its shopping cart from the DB appropriately
     * Customer ID will be a foreign key in the DB
     * Retrieve the last receipt method from data storage and enter the last ID
     */
    public void emptyCustomerShoppingCart()
    {
        
        string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Files\\shoppingCarts.txt";
        List<string> shoppingCartInDB = File.ReadAllLines(path).ToList();
        int customerID = 0;
        if (shoppingCartInDB != null || shoppingCartInDB != "")
        {
            for (int i = 0; i < shoppingCartInDB.Length; i++)
            {
                string[] singleSC = shoppingCartInDB.Split(new string[] { ": " }, StringSplitOptions.None);
                string[] singleSCInfo = singleSC[1].Split(new string[] { ", " }, StringSplitOptions.None);
                //The first index is the ID of the receipt
                Int32.TryParse(singleSCInfo[1], out customerID);
                if (this.customer_ID == customerID)
                {
                    //Remove the shopping cart of the respective customer from the DB since payment has been approved
                    shoppingCartInDB.RemoveAt(i);
                    File.WriteAllLines(path, shoppingCartInDB.ToArray());
                }
            }//end for loop

        }
    }
    
}