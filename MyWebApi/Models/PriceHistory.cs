namespace MyWebApi.Models
{
    public class PriceHistory
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public decimal OldPrice { get; set; }
        public DateTime ChangedAt { get; set; }

        public Product Product { get; set; } = null!;
    }
}