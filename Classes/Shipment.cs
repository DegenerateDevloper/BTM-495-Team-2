using System.Text.RegularExpressions;
using System.Windows;
using System.IO;
using System.Reflection;
using System;

public class Shipment
{
    public int shipment_ID { get; set; }
    public decimal shipment_cost { get; set; }
    public DateTime shipment_date { get; set; }
    public string shipment_status { get; set; }
    public string shipment_type { get; set; }
    public List<DeliveryMethod> delivery_method { get; set; }
    public ShoppingCart shopping_cart { get; set; }
     private readonly Notification emailNotification;

    public Shipment(int shipmentID, decimal shipmentCost, DateTime shipmentDate, string status, string type)
    {
        this.shipment_ID = shipmentID;
        this.shipment_cost = shipmentCost;
        this.shipment_date = shipmentDate;
        this.shipment_status = status;
        this.shipment_type = type;
        this.emailNotification = emailNotification;
    }

    public Shipment(decimal shipmentCost, DateTime shipmentDate, string status, string type)
    {
        //Retrieve the last shipment from data storage and enter the last ID
        string path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\Files\\shipment.txt";
        string lastShipment = File.ReadLines(path).Last();
        int lastShipmentID = 0;
        if (lastShipment != null || lastShipment != "")
        {
            string[] singleShipment = lastShipment.Split(new string[] { ": " }, StringSplitOptions.None);
            //The first index is the ID of the shipment
            Int32.TryParse(singleShipment[0], out lastShipmentID + 1);
        }

        this.shipment_ID = lastShipmentID;
        this.shipment_cost = shipmentCost;
        this.shipment_date = shipmentDate;
        this.shipment_status = status;
        this.shipment_type = type;
    }

    public bool SendShipmentNotification(string recipientEmail, string deliveryMethod)
    {
        string subject = "Shipment Notification";
        string body = $"Your shipment is scheduled for delivery via {deliveryMethod}. For more details, please contact our support team.";

        return emailNotification.SendEmail(recipientEmail, subject, body, senderPassword);
    }
}