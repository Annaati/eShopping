using Basket.Core.Entities;

namespace Basket.Core.Repositories
{
    public interface IShoppingBasketRepository
    {
        Task<ShoppingBasket> GetBasket(string userName);
        Task<ShoppingBasket> UpdateBasket(ShoppingBasket basket);
        Task DeleteBasket(string userName);
    }
}
