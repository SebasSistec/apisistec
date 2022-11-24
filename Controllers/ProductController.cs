using apisistec.Dtos;
using apisistec.Dtos.Product;
using apisistec.Helpers;
using apisistec.Interfaces;
using apisistec.Models.Parameters;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace apisistec.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductService _productService;
        DefaultResponses response = new();
        
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetProducts([FromQuery] QueryStringParams qParams, string companyId)
        {
            PaginationDto<ProductDto> products  = _productService.GetProducts(companyId, qParams);
            return Ok(response.SuccessResponse("Ok", products));
        }
    }
}
