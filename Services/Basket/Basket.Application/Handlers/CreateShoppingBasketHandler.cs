using Basket.Application.Commands;
using Basket.Application.Mappers;
using Basket.Application.Responses;
using Basket.Core.Entities;
using Basket.Core.Repositories;
using MediatR;

namespace Basket.Application.Handlers
{
    public class CreateShoppingBasketHandler : IRequestHandler<UpdatehoppingBasketCommand, ShoppingBasketResponse>
    {
        private readonly IShoppingBasketRepository _shoppingBasketRepository;

        public CreateShoppingBasketHandler(IShoppingBasketRepository shoppingBasketRepository)
        {
            _shoppingBasketRepository = shoppingBasketRepository;
        }

        public async Task<ShoppingBasketResponse> Handle(UpdatehoppingBasketCommand request, CancellationToken cancellationToken)
        {
            //TODO: Call Discount Service and Apply Coupon

            var shoppingBasket = await _shoppingBasketRepository.UpdateBasket(new ShoppingBasket
            {
                UserName = request.UserName,
                Items = request.Items
            });

            var shoppingBasketResponse = BasketMapper.Mapper.Map<ShoppingBasketResponse>(shoppingBasket);

            return shoppingBasketResponse;
        }
    }
}
