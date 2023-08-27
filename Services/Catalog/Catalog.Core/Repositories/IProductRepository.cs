using Catalog.Core.Entities;
using Catalog.Core.Specs;

namespace Catalog.Core.Repositories
{
    public interface IProductRepository
    {

        Task<Pagination<Product>> GetAllProducts(CatalogSpecParams catalogSpecParams);
        Task<IEnumerable<Product>> GetProductByName(string name);
        Task<IEnumerable<Product>> GetProductByBrand(string brand);
        Task<IEnumerable<Product>> GetProductByType(string type);
        Task<Product> GetProductById(string id);
        Task<Product> CreateProduct(Product product);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(string id);
    }
}
