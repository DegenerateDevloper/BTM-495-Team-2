public class Receipt
{
    public int receipt_ID { get; set; }
    public List<Product> products_bought { get; set; }
    public Customer customer { get; set; }
    public int total_cost { get; set; }
    public Payment payment { get; set; }

    public int retrieveReceipt(int customer_ID) 
    {
        // Logic to come
    }
    
}