using Catalog.Application.Commands;
using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using MediatR;

namespace Catalog.Application.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, bool>
    {
        private readonly IProductRepository _productRepository;
        public UpdateProductHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<bool> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var productEntity = await _productRepository.UpdateProduct(new Product
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                Summery = request.Summery,
                ImageFile = request.ImageFile,
                Brands = request.Brands,
                Types = request.Types,
                Price = request.Price
            });

            return productEntity;
        }
    }
}
