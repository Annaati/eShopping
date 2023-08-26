using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Core.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsquery, IList<ProductResponse>>
    {
        private readonly IProductRepository _productRepository;

        public GetAllProductsHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<IList<ProductResponse>> Handle(GetAllProductsquery request, CancellationToken cancellationToken)
        {
            var productList = await _productRepository.GetAllProducts();
            var productResponse = ProductMapper.mapper.Map<IList<ProductResponse>>(productList);

            return productResponse;
        }
    }
}
