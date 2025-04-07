namespace MyWebApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        public List<ProductReview> Reviews { get; set; } = new();
        public List<PriceHistory> PriceHistories { get; set; } = new();
    }
}