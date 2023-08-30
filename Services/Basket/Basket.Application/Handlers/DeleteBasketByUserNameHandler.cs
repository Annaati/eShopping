using Basket.Application.Queries;
using Basket.Core.Repositories;
using MediatR;

namespace Basket.Application.Handlers
{
    public class DeleteBasketByUserNameHandler : IRequestHandler<DeleteBasketByUserNameQuery>
    {
        private readonly IShoppingBasketRepository _shoppingBasketRepository;

        public DeleteBasketByUserNameHandler(IShoppingBasketRepository shoppingBasketRepository)
        {
            _shoppingBasketRepository = shoppingBasketRepository;
        }
        
        public async Task<Unit> Handle(DeleteBasketByUserNameQuery request, CancellationToken cancellationToken)
        {
            await _shoppingBasketRepository.DeleteBasket(request.UserName);
            return Unit.Value;
        }

        async Task IRequestHandler<DeleteBasketByUserNameQuery>.Handle(DeleteBasketByUserNameQuery request, CancellationToken cancellationToken)
        {
            await _shoppingBasketRepository.DeleteBasket(request.UserName);

        }
    }
}
