using System.Text;
using System.Windows;
using System.IO;
using System.Reflection;
using System;

public class SupplierPurchaseOrder
{
    public int supplier_purchase_order_ID { get; set; }
    public bool purchase_orders_received { get; set; }
    public DateTime purchase_order_date { get; set; }
    public List<Product> products { get; set; }
    private readonly Notification emailNotification;

    public SupplierPurchaseOrder(int supplierPOID, bool purchase_orders_received, DateTime purchase_order_date, List<Product> products)
    {
        this.supplier_purchase_order_ID = supplierPOID;
        this.purchase_orders_received = purchase_orders_received;
        this.purchase_order_date = purchase_order_date;
        this.products = products;
        this.emailNotification = emailNotification;
    }

    public SupplierPurchaseOrder(bool purchase_orders_received, DateTime purchase_order_date, List<Product> products)
    {
        //Retrieve the last supplier purchase order from data storage and enter the last ID
        string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Files\\supplierPO.txt";
        string lastSupplierPO = File.ReadLines(path).Last();
        int lastSupplierPOID = 0;
        if (lastSupplierPO != null || lastSupplierPO != "")
        {
            string[] singleSupplierPO = lastSupplierPO.Split(new string[] { ": " }, StringSplitOptions.None);
            //The first index is the ID of the payment method
            Int32.TryParse(singleSupplierPO[0], out lastSupplierPOID + 1);
        }
        this.supplier_purchase_order_ID = lastSupplierPOID;
        this.purchase_orders_received = purchase_orders_received;
        this.purchase_order_date = purchase_order_date;
        this.products = products;
    }

    public void addProduct(Product product)
    {
        //Add product to list
        this.products.Add(product);
        
        //Add product to data store, will need to add a remove method and will need to maybe integrate a better one or a different matter
        
        //First remove the existing record from the file
        string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Files\\supplierPO.txt";
        List<string> supplierPOList = File.ReadAllLines(path).ToList();
        int index = 0;
        for (int x=0; x<supplierPOList; x++)
        {
            string[] singleSupplierPO = lastSupplierPO.Split(new string[] { ": " }, StringSplitOptions.None);
            if (singleSupplierPO[0].Equals(this.supplier_purchase_order_ID))
            {
                index = x; break;
            }
        }
        supplierPOList.RemoveAt(index);
        File.WriteAllLines(path, supplierPOList.ToArray());

        //Readd the SPO record but with the new product in the list
        StreamWriter addProdtoSPO = new StreamWriter(path);
        string insertLine = this.supplier_purchase_order_ID+": "+this.purchase_orders_received+", "+purchase_order_date+". Products: ";
        for (int i = 0; i < this.products.length; i++) 
        {
            if (i == this.products.length - 1)
            {
                string.Concat(insertLine, this.products[i].product_name + ".");
            }
            else
            {
                string.Concat(insertLine, this.products[i].product_name + ", ");
            }
        }
        addProdtoSPO.WriteLine(insertLine);
        addProdtoSPO.Close();
    }

    public bool SendPONotification(string recipientEmail, string SupplierPurchaseOrder)
    {
        string subject = "PO Notification";
        string body = $"Here is your purchase order: {SupplierPurchaseOrder}. For more details, please contact our support team.";

        return emailNotification.SendEmail(recipientEmail, subject, body);
    }

    public bool confirmationPopUp()
    {
        if (SendPONotification == true)
        {
            string title = "PO Email Sent";
            string message = $"The email containing the PO has been sent to the supplier";

            return emailNotification.ShowNotification(title, message);
        }
    }
}