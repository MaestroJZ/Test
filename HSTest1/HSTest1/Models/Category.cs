namespace HCTest1.Models
{

    public class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ICollection<Product>? Products { get; set; }
        public ICollection<CategoryAttribute>? Attributes { get; set; }
    }

    public class CategoryAttribute
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Value { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public double? Price { get; set; }
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
