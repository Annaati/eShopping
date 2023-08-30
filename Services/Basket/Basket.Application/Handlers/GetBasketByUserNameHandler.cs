using Basket.Application.Mappers;
using Basket.Application.Queries;
using Basket.Application.Responses;
using Basket.Core.Repositories;
using MediatR;

namespace Basket.Application.Handlers
{
    public class GetBasketByUserNameHandler : IRequestHandler<GetBasketByUserNameQuery, ShoppingBasketResponse>
    {
        private readonly IShoppingBasketRepository _shoppingBasketRepository;

        public GetBasketByUserNameHandler(IShoppingBasketRepository shoppingBasketRepository)
        {
            _shoppingBasketRepository = shoppingBasketRepository;
        }
        public async Task<ShoppingBasketResponse> Handle(GetBasketByUserNameQuery request, CancellationToken cancellationToken)
        {
            var shoppingCart = await _shoppingBasketRepository.GetBasket(request.UserName);
            var shoppingCartResponse = BasketMapper.Mapper.Map<ShoppingBasketResponse>(shoppingCart);
            return shoppingCartResponse;
        }
    }
}