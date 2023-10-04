namespace GeekShopping.Product.API.DTO
{
    public class ProductDTO
    {
        public long Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public string CategoryName { get; set; } = string.Empty;
        public string ImageURL { get; set; } = string.Empty;
    }
}
