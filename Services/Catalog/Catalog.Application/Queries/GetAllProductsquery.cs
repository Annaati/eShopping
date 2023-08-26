using Catalog.Core.Application.Responses;
using MediatR;

namespace Catalog.Application.Queries
{
    public class GetAllProductsquery : IRequest<IList<ProductResponse>>
    {
    }
}
