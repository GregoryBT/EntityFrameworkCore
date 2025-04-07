namespace MyWebApi.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int? ParentCategoryId { get; set; }

        public Category? ParentCategory { get; set; }
        public List<Category> SubCategories { get; set; } = new();
        public List<Product> Products { get; set; } = new();
    }
}