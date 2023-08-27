using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Core.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class GetProductByBrandHandler : IRequestHandler<GetProductByBrandQuery, IList<ProductResponse>>
    {
        private readonly IProductRepository _productRepository;
        public GetProductByBrandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IList<ProductResponse>> Handle(GetProductByBrandQuery request, CancellationToken cancellationToken)
        {
            var productsList = await _productRepository.GetProductByBrand(request.Brand);
            var productsResponse = ProductMapper.Mapper.Map<IList<ProductResponse>>(productsList);

            return productsResponse;
        }
    }
}
