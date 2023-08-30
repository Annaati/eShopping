﻿namespace Basket.Core.Entities
{
    public class BasketCartItem
    {
        public string ProductId { get; set; }
        public string ProductName { get; set; }
        public string ImageFile { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
