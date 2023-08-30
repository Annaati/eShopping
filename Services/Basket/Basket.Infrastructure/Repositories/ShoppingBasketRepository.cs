using Basket.Core.Entities;
using Basket.Core.Repositories;

namespace Basket.Infrastructure.Repositories
{
    public class ShoppingBasketRepository : IShoppingBasketRepository
    {
        public Task DeleteBasket(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<ShoppingBasket> GetBasket(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<ShoppingBasket> UpdateBasket(ShoppingBasket basket)
        {
            throw new NotImplementedException();
        }
    }
}
