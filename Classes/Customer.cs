using System.Text.RegularExpressions;
using System.Windows;
using System.IO;
using System.Reflection;
using System;

public class Customer : User
{
    private string customer_email;
    private string customer_address;
    private string customer_password;
    private List<Product> customer_cart;
    private bool customer_is_confirmed;

    public string customer_email
    {
        get { return customer_email; }
        set { customer_email = value; }
    }

    public string customer_address
    {
        get { return customer_address; }
        set { customer_address = value; }
    }

    public string customer_password
    {
        get { return customer_password; }
        set { customer_password = value; }
    }

    public List<Product> CustomerCart
    {
        get { return customer_cart; }
    }

    public bool CustomerIsConfirmed
    {
        get { return customer_is_confirmed; }
        set { customer_is_confirmed = value; }
    }
    public void SendConfirmationEmail()
    {
        Console.WriteLine("Confirmation email sent to: " + customer_email);
    }


    /**
     * Verify if the customer has a Tact Gearz account in order to dertermine if we can retrieve the existing payment method,
     * or if the customer needs to enter a new payment method
     */
    public bool custHasTGAccount()
    {
        //Check if the customer has a Tact Gearz account
        string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Files\\paymentMethod.txt";
        string[] paymentMethodInDB = File.ReadLines(path).Split(new string[] { "\n" }, StringSplitOptions.None);
        int pmID = 0;
        int cvc = 0;
        int cardnum = 0;
        DateTime expDate = 0;
        int customerIDFromPM = 0;
        bool isMainTGPaymentMethod = false;
        if (paymentMethodInDB != null || paymentMethodInDB != "")
        {
            for (int i = 0; i < paymentMethodInDB.Length; i++)
            {
                string[] singlePM = paymentMethodInDB[i].Split(new string[] { ": " }, StringSplitOptions.None);
                //The first index is the ID of the payment method
                string[] singlePMInfo = singlePM[1].Split(new string[] { ", " }, StringSplitOptions.None);
                Int32.TryParse(singlePM[0], out pmID);
                Int32.TryParse(singlePMInfo[5], out customerIDFromPM);
                Boolean.TryParse(singlePMInfo[6], out isMainTGPaymentMethod);
                if (customerIDFromPM == this.user_ID && isMainTGPaymentMethod == true)
                {
                    //Customer does not have to enter payment manually since he already has a Tact Gearz account
                    return true;
                }

            }//end for loop
        }
        return false;
    }//end method custHasTGAccount
}
