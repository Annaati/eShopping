using MediatR;
using Catalog.Application.Commands;
using Catalog.Core.Application.Responses;
using Catalog.Core.Repositories;
using Catalog.Application.Mappers;
using Catalog.Core.Entities;

namespace Catalog.Application.Handlers
{
    public class CreateProductHandler : IRequestHandler<CreateProductCommand, ProductResponse>
    {
        private readonly IProductRepository _productRepository;
        public CreateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ProductResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var ProductEntity = ProductMapper.Mapper.Map<Product>(request);

            if(ProductEntity == null)
            {
                throw new ArgumentException(nameof(request));
            }

            var newProuduct = await _productRepository.CreateProduct(ProductEntity);
            var ProductResponse = ProductMapper.Mapper.Map<ProductResponse>(newProuduct);

            return ProductResponse;
        }
    }
}
