using MediatR;
using Basket.Application.Response;

namespace Basket.Application.Queries
{
    public class GetBasketByUserNameQuery : IRequest<ShoppingBasketResponse>
    {
       public string UserName { get; set; }

        public GetBasketByUserNameQuery(string userName)
        {
            UserName = userName;
        }
    }
}
