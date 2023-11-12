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
        delivery_method_ID = deliveryMethodID;
        delivery_method_type = deliveryMethodType;
        availability = availability;
    }

    public void setAvailability(bool newAvailability)
    {
        availability = newAvailability;
    }

    public bool getAvailability()
    {
        return Availability;
    }
}
