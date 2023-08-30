using Basket.Application.Responses;
using Basket.Core.Entities;
using MediatR;

namespace Basket.Application.Commands
{
    public class UpdatehoppingBasketCommand : IRequest<ShoppingBasketResponse>
    {
        public UpdatehoppingBasketCommand(string userName, List<ShoppingBasketItem> items)
        {
            UserName = userName;
            Items = items;
        }
        public string UserName { get; set; }
        public List<ShoppingBasketItem> Items { get; set; }
    }
}
