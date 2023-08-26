using Catalog.Application.Mappers;
using Catalog.Application.Queries;
using Catalog.Core.Application.Responses;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class GetProductByNameHandler : IRequestHandler<GetProductByNameQuery, IList<ProductResponse>>
    {
        private readonly IProductRepository _productRepository;
        public GetProductByNameHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IList<ProductResponse>> Handle(GetProductByNameQuery request, CancellationToken cancellationToken)
        {
            var productsList = await _productRepository.GetProductByName(request.Name);
            var productsResponse = ProductMapper.mapper.Map<IList<ProductResponse>>(productsList);

            return productsResponse;
        }
    }
}
