using Catalog.Core.Application.Responses;
using Catalog.Core.Specs;
using MediatR;

namespace Catalog.Application.Queries
{
    public class GetAllProductsquery : IRequest<Pagination<ProductResponse>>
    {
        public CatalogSpecParams CatalogSpecParams { get; set; }

        public GetAllProductsquery(CatalogSpecParams catalogSpecParams)
        {
            CatalogSpecParams = catalogSpecParams;
        }
    }
}
