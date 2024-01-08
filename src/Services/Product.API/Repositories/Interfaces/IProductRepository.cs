using Product.API.Entities;
using Product.API.Persistence;
using Contracts.Domains.Interfaces;

namespace Product.API.Repositories.Interfaces
{
    public interface IProductRepository : IRepositoryBase<CatalogProduct, Guid, ProductContext>
    {
        Task<IEnumerable<CatalogProduct>> GetProductsAsync();
        Task<CatalogProduct> GetProductAsync(Guid id);
        Task<CatalogProduct> GetProductByNoAsync(string productNo);
        Task CreateProductAsync(CatalogProduct product);
        Task UpdateProductAsync(CatalogProduct product);
        Task DeleteProductAsync(Guid id);
    }
}
