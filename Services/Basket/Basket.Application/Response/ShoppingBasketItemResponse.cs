namespace Basket.Application.Response
{
    public class ShoppingBasketItemResponse
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ImageFile { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
    }
}
