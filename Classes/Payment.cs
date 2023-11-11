using System.IO;

public class Payment
{
    private int payment_ID;
    private int order_ID;
    private CustomerPurchaseOrder order_total;
    //private PaymentMethod payment_details;
    private List<Receipt> receipts;

    public PaymentMethod(int orderID, CustomerPurchaseOrder orderTotal, List<Receipt> receipts)
    {
        //Retrieve the last payment method from data storage and enter the last ID
        string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Files\\payment.txt";
        string lastPayment = File.ReadLines(path).Last();
        int lastPaymentID = 0;
        if (lastPayment != null || lastPayment != "")
        {
            string[] singlePayment = lastPayment.Split(new string[] { ": " }, StringSplitOptions.None);
            //The first index is the ID of the payment
            Int32.TryParse(singlePayment[1], out lastPaymentID + 1);
        }
        this.payment_ID = lastPaymentID;
        this.order_ID = orderID;
        this.order_total = orderTotal;
        this.receipts = receipts;
    }

    public processPayment(int customer_ID, int delivery_method_type, PaymentMethod pm)
    {
        //Since we already sent the payment, we want to validate if it is valid or not
        //First, we know that the customer already exists so we validate if the payment method is valid

        return 0;
        //Retrieve the data storage with the receipts and add at the new one at the end of it and return the ID.
        string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Files\\receipt.txt";
        Receipt newReceipt = new Receipt();
        int newReceiptId = newReceipt.createReceipt();
        return newReceiptId;
    }
}