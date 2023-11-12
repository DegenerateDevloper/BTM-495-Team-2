using System.Linq;
using Newtonsoft.Json;

public class Receipt
{
    public int receipt_ID { get; set; }
    public List<Product> products_bought { get; set; }
    public int customer_ID { get; set; }
    public decimal total_cost { get; set; }
    public Payment payment { get; set; }

    public Receipt(List<Product> productsBought, int customerID, Payment aPayment)
    {
        // Retrieve the last receipt method from data storage and enter the last ID
        string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Files\\receipt.txt";
        string lastPayment = File.ReadLines(path).Last();
        int lastPaymentID = 0;
        if (lastPayment != null || lastPayment != "")
        {
            string[] singlePayment = lastPayment.Split(new string[] { ": " }, StringSplitOptions.None);
            //The first index is the ID of the payment
            Int32.TryParse(singlePayment[1], out lastPaymentID + 1);
        }
        this.receipt_ID = lastReceiptID;
        this.products_bought = productsBought;
        this.customer_ID = customerID;
        this.total_cost = productsBought.Sum(singleProd => singleProd.product_price);
        this.payment = aPayment;
    }

    public int retrieveReceipt() 
    {
        //Enter the current receipt into data store as a matter of proof
        StreamWriter newReceipt = new StreamWriter(path + "\\Files\\receipts.txt");
        newReceipt.WriteLine(JsonConvert.SerializeObject(this));
        newReceipt.Close();
        return this.receipt_ID;
    }
    
}