using MediatR;
using Basket.Application.Queries;
using Basket.Application.Response;
using Basket.Core.Repositories;

namespace Basket.Application.Handlers
{
    public class GetBasketByUserNameHandler : IRequestHandler<GetBasketByUserNameQuery, ShoppingBasketResponse>
    {
        private readonly IBasketRepository _basketRepository;
        public GetBasketByUserNameHandler(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        public async Task<ShoppingBasketResponse> Handle(GetBasketByUserNameQuery request, CancellationToken cancellationToken)
        {
            var basket = await _basketRepository.GetBasket(request.UserName);

            if (basket == null)
                return new ShoppingBasketResponse(request.UserName);


        }
    }
}
