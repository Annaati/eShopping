using Basket.Core.Enitities;
using Basket.Core.Repositories;
using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Basket.Infrastructure.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _redisCache;

        public BasketRepository(IDistributedCache redisCache)
        {
            _redisCache = redisCache;
        }

        

        public async Task<ShoppingBasket> GetBasket(string userName)
        {
            var basket = await _redisCache.GetStringAsync(userName);
            if (string.IsNullOrEmpty(basket))
                return null;

            return JsonSerializer.Deserialize<ShoppingBasket>(basket);
        }


        public async Task<ShoppingBasket> UpdateBasket(ShoppingBasket basket)
        {
            await _redisCache.SetStringAsync(basket.UserName, JsonSerializer.Serialize(basket));
            return await GetBasket(basket.UserName);
        }


        public async Task DeleteBasket(string userName)
        {
            await _redisCache.RemoveAsync(userName);
        }





    }
}
