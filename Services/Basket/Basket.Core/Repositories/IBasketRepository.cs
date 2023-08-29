using Basket.Core.Enitities;

namespace Basket.Core.Repositories
{
    public interface IBasketRepository
    {
        Task<ShoppingBasket> GetBasket(string userName);
        Task<ShoppingBasket> UpdateBasket(ShoppingBasket basket);
        Task DeleteBasket(string userName);
    }
}
