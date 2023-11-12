using System.Text.RegularExpressions;
using System.Windows;
using System.IO;
using System.Reflection;
using System;

public class PaymentMethod
{
    public int pmethod_ID { get; set; }
    public string pmethod_type { get; set; }
    public int cvc_code { get; set; }
    public int card_number { get; set; }
    public string cardholder_name { get; set; }
    public DateTime expiration_date { get; set; }
    //public List<Customer> customers { get; set; }

    public PaymentMethod(int pmethodID, string pmethodtype, int cvc, int cardNumber, string cardholderName, DateTime expirationDate)
    {
        this.pmethod_ID = pmethodID;
        this.pmethod_type = pmethodtype;
        this.cvc_code = cvc;
        this.card_number = cardNumber;
        this.cardholder_name = cardholderName;
        this.expiration_date = expirationDate;
    }

    public PaymentMethod(string pmethodtype, int cvc, int cardNumber, string cardholderName, DateTime expirationDate)
    {
        //Retrieve the last payment method from data storage and enter the last ID
        string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Files\\payment_method.txt";
        string lastPaymentMethod = File.ReadLines(path).Last();
        int lastPaymentMethodID = 0;
        if (lastPaymentMethod != null || lastPaymentMethod != "")
        {
            string[] singlePaymentMethod = lastPaymentMethod.Split(new string[] { ": " }, StringSplitOptions.None);
            //The first index is the ID of the payment method
            Int32.TryParse(singlePaymentMethod[0], out lastPaymentMethodID + 1);
        }
        this.pmethod_ID = lastPaymentMethodID;
        this.pmethod_type = pmethodtype;
        this.cvc_code = cvc;
        this.card_number = cardNumber;
        this.cardholder_name = cardholderName;
        this.expiration_date = expirationDate;
    }

    public void sendPaymentMethod() 
    {
        //Just send all the details to Process Payment class
        Payment payment = new Payment();
        int newReceiptId = payment.processPayment(customerID, deliveryMethodType, this);
        return newReceiptId;
    }

}