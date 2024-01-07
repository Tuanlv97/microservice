using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Product.API.Services.Interfaces;
using Shared.DTOs.Product;
using System.ComponentModel.DataAnnotations;

namespace Product.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService ?? throw new ArgumentNullException(nameof(productService));
        }

        #region CRUD
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productService.GetProductsAsync();
            return Ok(products);
        }
        [HttpGet("{id:guid}")]
       // [ClaimRequirement(FunctionCode.PRODUCT, CommandCode.VIEW)]
        public async Task<IActionResult> GetProduct([Required] Guid id)
        {
            var product = await _productService.GetProductAsync(id);
            return Ok(product);
        }

        #endregion CRUD
    }

}
