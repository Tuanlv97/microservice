using AutoMapper;
using Product.API.Entities;
using Product.API.Repositories.Interfaces;
using Product.API.Services.Interfaces;
using Shared.DTOs.Product;
using ILogger = Serilog.ILogger;

namespace Product.API.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly ILogger _logger;

        public ProductService(IMapper mapper, IProductRepository productRepository, ILogger logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<ProductDto> GetProductAsync(Guid id)
        {
            _logger.Information($"BEGIN: GetProductAsync ById : {id}");
            var product = await _productRepository.GetProductAsync(id) ?? throw new Exception("Không tìm thấy bản ghi trong hệ thông");
            var result = _mapper.Map<ProductDto>(product);
            _logger.Information($"END: GetProductAsync ById {id}");

            return result;
        }

        public async Task<IEnumerable<ProductDto>> GetProductsAsync()
        {
            _logger.Information($"BEGIN: GetProducts");
            var products = await _productRepository.GetProductsAsync();
            var result = _mapper.Map<IEnumerable<ProductDto>>(products);
            _logger.Information($"END: GetProducts");
            return result;
        }
    }
}
