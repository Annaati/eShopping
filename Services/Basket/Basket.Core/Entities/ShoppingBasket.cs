namespace Basket.Core.Entities
{
    public class ShoppingBasket
    {
        public string UserName { get; set; }
        public List<ShoppingBasketItem> Items { get; set; } = new List<ShoppingBasketItem>();

        public ShoppingBasket()
        {

        }

        public ShoppingBasket(string userName)
        {
            UserName = userName;
        }
    }
}
