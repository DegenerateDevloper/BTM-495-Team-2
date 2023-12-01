using System.Text.RegularExpressions;
using System.Windows;
using System.IO;
using System.Reflection;
using System;

public class Payment
{
    private int payment_ID;
    private int order_ID;
    private CustomerPurchaseOrder order_total;
    private CustomerPurchaseOrder refund_amount;
    private string payment_status;

    public Payment(int paymentID, int orderID, CustomerPurchaseOrder orderTotal, string paymentStatus)
    {
        this.payment_ID = paymentID;
        this.payment_ID = lastPaymentID;
        this.order_ID = orderID;
        this.order_total = orderTotal;
        this.payment_status = "Pending";
        //this.receipts = receipts;
    }

    public Payment(int orderID, CustomerPurchaseOrder orderTotal, string paymentStatus)
    {
        //Retrieve the last payment from data storage and enter the last ID
        string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Files\\payment.txt";
        string lastPayment = File.ReadLines(path).Last();
        int lastPaymentID = 0;
        if (lastPayment != null || lastPayment != "")
        {
            string[] singlePayment = lastPayment.Split(new string[] { ": " }, StringSplitOptions.None);
            //The first index is the ID of the payment
            Int32.TryParse(singlePayment[0], out lastPaymentID + 1);
        }
        this.payment_ID = lastPaymentID;
        this.order_ID = orderID;
        this.order_total = orderTotal;
        this.payment_status = "Pending";
    }

    public processPayment(int customer_ID, int delivery_method_type, PaymentMethod pm, List<Product> productsBought)
    {
        //Since we already sent the payment, we want to validate if it is valid or not
        //First, we know that the customer already exists so we validate if the payment method is valid
        
        if(pm.pmethod_type.Equals("credit") || pm.pmethod_type.Equals("debit")) 
        {
            //Customer is paying with credit or debit
            //Validate card number
            Regex isCardNumber = new Regex(@"^(?: 4[0 - 9]{ 12 }(?:[0 - 9]{ 3})?|[25][1 - 7][0 - 9]{ 14}| 6(?:011 | 5[0 - 9][0 - 9])[0 - 9]{ 12}| 3[47][0 - 9]{ 13}| 3(?:0[0 - 5] |[68][0 - 9])[0 - 9]{ 11}| (?: 2131 | 1800 | 35\d{ 3})\d{ 11})$");
            Regex isCVC = new Regex(@"^[0-9]{3, 4}$");
            Regex isCardholderName = new Regex(@"^((?:[A-Za-z]+ ?){1,3})$");
            Regex isExpirationDate = new Regex(@"(0[1-9]|10|11|12)/20[0-9]{2}$");
            if (!isCardNumber.IsMatch(pm.card_number.ToString()) || !isCVC.IsMatch(pm.cvc_code) || !isCardholderName.IsMatch(pm.cardholder_name) || !isExpirationDate.IsMatch(pm.expiration_date.ToString("MM/yyyy")))
            {
                //Some information on the card is not valid, so return 0 for false
                return 0;
                this.payment_status = "Failed";
            }

            //Create a customer purchase order
            CustomerPurchaseOrder newCPO = new CustomerPurchaseOrder();
            newCPO.insertCPO();
            this.payment_status = "Approved";
        }
        else
        {
            //Customer is paying in another fashion where cards are not involved
            CustomerPurchaseOrder newCPO = new CustomerPurchaseOrder();
            newCPO.insertCPO();
            this.payment_status = "Approved";
        }

        //Retrieve the data storage with the receipts and add at the new one at the end of it and return the ID.
        string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Files\\receipt.txt";
        Receipt newReceipt = new Receipt(productsBought, customer_ID, this);
        int newReceiptId = newReceipt.createReceipt();
        return newReceiptId;
    }

    public bool issueRefund(decimal refund_amount, int payment_ID)
    {
        bool refundSuccessful = SimulateRefundProcess(refund_amount, payment_ID);

        if (refundSuccessful)
        {
            Console.WriteLine($"Refund of {refund_amount:C} for payment ID: {payment_ID} processed successfully.");
            return true;
        }
        else
        {
            Console.WriteLine($"Refund of {refund_amount:C} for payment ID: {payment_ID} failed.");
            return false;
        }
    }
    private bool simulateRefundProcess(decimal amount, int payment_ID)
    {
        return true;
    }
}