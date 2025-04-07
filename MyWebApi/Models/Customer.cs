namespace MyWebApi.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public Address? ShippingAddress { get; set; }
        public Address? BillingAddress { get; set; }

        public List<Order> Orders { get; set; } = new();
        public List<ProductReview> Reviews { get; set; } = new();
    }
}