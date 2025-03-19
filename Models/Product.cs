namespace ECommerceLabb.Models
{
    public enum ProductCategory
    {
        Clothes,
        Electronics,
        Food,
        Other
    }

    public enum ProductStatus
    {
        Available,
        Unavailable
    }
    public class Product
    {
        public string? Id { get; set; }
        public string ProductNumber { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public ProductCategory Category { get; set; } = ProductCategory.Other;
        public ProductStatus Status { get; set; } = ProductStatus.Available;
    }
}
