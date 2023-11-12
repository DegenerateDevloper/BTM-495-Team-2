using System.Text;
using System.Windows;
using System.IO;
using System.Reflection;
using System;


public class Supplier
{
    public int supplier_ID { get; set; }
    public string supplier_email { get; set; }
    public int supplier_phone { get; set; }
    public string supplier_address { get; set; }

    public Supplier(int supplierID, string supplierEmail, int supplierPhone, string supplierAdress)
    {
        this.supplier_ID = supplierID;
        this.supplier_email = supplierEmail;
        this.supplier_phone = supplierphone;
        this.supplier_address = supplierAdress;
    }

    public Supplier(string supplierEmail, int supplierPhone, string supplierAdress)
    {
        //Retrieve the last supplier from data storage and enter the last ID
        string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Files\\suppliers.txt";
        string lastSupplier = File.ReadLines(path).Last();
        int lastSupplierID = 0;
        if (lastSupplier != null || lastSupplier != "")
        {
            string[] singleSupplier = lastSupplier.Split(new string[] { ": " }, StringSplitOptions.None);
            //The first index is the ID of the payment method
            Int32.TryParse(singleSupplier[0], out lastSupplierID + 1);
        }
        this.supplier_ID = lastSupplierID;
        this.supplier_email = supplierEmail;
        this.supplier_phone = supplierphone;
        this.supplier_address = supplierAdress;
    }
}