using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Core.Application.Responses;
using Catalog.Core.Repositories;
using Catalog.Core.Specs;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsquery, Pagination<ProductResponse>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<Pagination<ProductResponse>> Handle(GetAllProductsquery request, CancellationToken cancellationToken)
        {
            var productList = await _productRepository.GetAllProducts(request.CatalogSpecParams);
            var productResponse = ProductMapper.Mapper.Map<Pagination<ProductResponse>>(productList);

            return productResponse;
        }
    }
}
