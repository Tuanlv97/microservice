using Product.API.Entities;
using Shared.DTOs.Product;

namespace Product.API.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProductsAsync();
        Task<ProductDto> GetProductAsync(Guid id);
    }
}
