using System;
using System.Collections.Generic;

public class DeliveryMethod
{
    private int delivery_method_ID;
    private int delivery_method_type;
    private bool availability;

    public int delivery_method_ID
    {
        get { return delivery_method_ID; }
        set { delivery_method_ID = value; }
    }

    public int delivery_method_type
    {
        get { return delivery_method_type; }
        set { delivery_method_type = value; }
    }

    public bool availability
    {
        get { return availability; }
        set { availability = value; }
    }


    public deliveryMethod(int deliveryMethodID, int deliveryMethodType, bool availability)
    {
        this.delivery_method_ID = deliveryMethodID;
        this.delivery_method_type = deliveryMethodType;
        this.availability = availability;
    }

    public void setAvailability(bool newAvailability)
    {
        this.availability = newAvailability;
    }

    public bool getAvailability()
    {
        return this.availability;
    }

    public bool DeliveryMethod selectDeliveryMethod(int methodChoice)
    {
        // Retrieve the delivery method that the customer wants
        string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Files\\deliveryMethod.txt";
        List<string> deliveryMethodInDB = File.ReadAllLines(path).ToList();
        int dmType = 0;
        int dmID = 0;
        bool availability = false;
        if (deliveryMethodInDB != null || deliveryMethodInDB != "")
        {
            for (int i = 0; i < productsInDB.Length; i++)
            {
                string[] singleDM = deliveryMethodInDB[i].Split(new string[] { ": " }, StringSplitOptions.None);
                //The first index is the ID of the product
                string[] singleDMInfo = singleDM[1].Split(new string[] { ", " }, StringSplitOptions.None);
                Int32.TryParse(singleDM[0], out dmID);
                Int32.TryParse(singleDMInfo[0], out dmType);
                if (dmType == methodChoice)
                {
                    Boolean.TryParse(singleDMInfo[1], out availability);
                    return availability;
                }
        else
        {
            return false;
        }
}
