using Product.API.Entities;
using Product.API.Persistence;
using Product.API.Repositories.Interfaces;
using Contracts.Domains.Interfaces;
using Infrastructure.Common.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Product.API.Repositories
{
    public class ProductRepository : RepositoryBase<CatalogProduct, Guid, ProductContext>, IProductRepository
    {
        public ProductRepository(ProductContext dbContext, IUnitOfWork<ProductContext> unitOfWork) : base(dbContext,
            unitOfWork)
        {
        }

        public async Task<IEnumerable<CatalogProduct>> GetProductsAsync()
        {
            return await FindAll().ToListAsync();
        }

        public Task<CatalogProduct> GetProductAsync(Guid id)
        {
            return GetByIdAsync(id);
        }

        public Task<CatalogProduct> GetProductByNoAsync(string productNo)
        {
            return FindByCondition(x => x.No.Equals(productNo)).SingleOrDefaultAsync();
        }

        public Task CreateProductAsync(CatalogProduct product)
        {
            return CreateAsync(product);
        }

        public Task UpdateProductAsync(CatalogProduct product)
        {
            return UpdateAsync(product);
        }

        public async Task DeleteProductAsync(Guid id)
        {
            var product = await GetProductAsync(id);
            if (product != null) await DeleteAsync(product);
        }
    }
}
