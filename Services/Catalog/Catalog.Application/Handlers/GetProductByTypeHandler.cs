using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Core.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class GetProductByTypeHandler : IRequestHandler<GetProductByTypeQuery, IList<ProductResponse>>
    {
        private readonly IProductRepository _productRepository;
        public GetProductByTypeHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IList<ProductResponse>> Handle(GetProductByTypeQuery request, CancellationToken cancellationToken)
        {
            var productsList = await _productRepository.GetProductByType(request.Type);
            var productsResponse = ProductMapper.Mapper.Map<IList<ProductResponse>>(productsList);

            return productsResponse;
        }
    }
}