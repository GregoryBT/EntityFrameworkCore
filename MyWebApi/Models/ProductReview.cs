namespace MyWebApi.Models
{
    public class ProductReview
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int Rating { get; set; } // De 1 à 5
        public string? Comment { get; set; }

        public Product Product { get; set; } = null!;
        public Customer Customer { get; set; } = null!;
    }

}