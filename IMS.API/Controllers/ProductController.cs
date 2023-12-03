using IMS.API.Validator;
using IMS.ClientEntity.ProductRequest;
using IMS.Service.productBrand;
using IMS.Service.productService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMS.API.Controllers
{
    [Route("api/")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly ProductValidator _productValidator;
        public ProductController(IProductService productService, ProductValidator productValidator = null)
        {
            _productService = productService;
            _productValidator = productValidator;
        }

        [HttpPost("products")]
        public async Task<IActionResult> ProductCreate([FromBody] ProductRequest request)
        {
            try
            {
                var validationResult = _productValidator.Validate(request);

                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult);
                }

                var isAdded = await _productService.Create(request);

                return isAdded ? Ok(new { isSuccess = true, StatusCode = "200", Status = "Ok", Message = "Data Create Succesfuly", Data = request })
                               : BadRequest(new { isSuccess = false, StatusCode = "400", Status = "Bad Request", Message = "Error in Request Object", Data = request });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
        [HttpGet("products")]
        
        public async Task<IActionResult> GetAllProduct([FromQuery] int page , [FromQuery]int pageSize)
        {
            try
            {
                var listOfProduct = await _productService.GetAll(page, pageSize);

                return listOfProduct is null ? NotFound(new { isSuccess = true, StatusCode = "404", Status = "Not Found", Message = "There is no  data", Data = listOfProduct })
                                           : Ok(new { isSuccess = true, StatusCode = "200", Status = "Ok", Message = "Data Retrived Succesfuly", Data = listOfProduct });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
