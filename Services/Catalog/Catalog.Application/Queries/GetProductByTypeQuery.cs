using Catalog.Core.Application.Responses;
using MediatR;

namespace Catalog.Application.Queries
{
    public class GetProductByTypeQuery : IRequest<IList<ProductResponse>>
    {
        public string Type { get; set; }

        public GetProductByTypeQuery(string type)
        {
            Type = type;
        }
    }
}
