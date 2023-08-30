namespace Basket.Application.Responses
{
    public class ShoppingBasketResponse
    {
        public string UserName { get; set; }
        public List<ShoppingBasketItemResponse> Items { get; set; }


        public ShoppingBasketResponse()
        {

        }

        public ShoppingBasketResponse(string userName)
        {
            UserName = userName;
        }

        public decimal TotalPrice
        {
            get
            {
                decimal totalPrice = 0;
                foreach (var item in Items)
                {
                    totalPrice += item.Price * item.Quantity;
                }
                return totalPrice;
            }
        }


    }
}
