namespace Floral_Shop.Models
{
    public class CartItem
    {
        public int BouquetId { get; set; }

        // The 'required' keyword ensures that these properties cannot be null (C# 11 or later)
        public required string Name { get; set; }

        public decimal Price { get; set; }

        public required string Image { get; set; } // Image path (required)

        public int Quantity { get; set; }

        // TotalPrice is calculated dynamically based on Price and Quantity
        public decimal TotalPrice => Price * Quantity;
    }
}
