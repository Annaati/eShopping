namespace Basket.Core.Entities
{
    public class ShoppingBasket
    {
        public string UserName { get; set; }

        public ShoppingBasket()
        {

        }

        public ShoppingBasket(string userName)
        {
            UserName = userName;
        }
    }
}
