using IMS.API.Validator;
using IMS.ClientEntity.ProductRequest;
using IMS.Service.productBrand;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security;

namespace IMS.API.Controllers
{
    [Route("api/")]
    [ApiController]
    //[Authorize]
    public class ProductBrandController : ControllerBase
    {
        private readonly IProductBrandService _productBrandService;
        private readonly ProductBrandValidator _brandValidator;


        public ProductBrandController(IProductBrandService productBrandService, ProductBrandValidator brandValidator)
        {
            _productBrandService = productBrandService;
            _brandValidator = brandValidator;
        }

        [HttpPost("Brands")]
        public async Task<IActionResult> BrandCreate([FromBody]ProductBrandRequest request)
        {
            try
            {
                var validationResult = _brandValidator.Validate(request);

                if(!validationResult.IsValid)
                {
                    return BadRequest(new { isSuccess = true, StatusCode = "400", Status = "Bad Request", Message = "Error in Request Object", Data = validationResult.Errors }); ;
                }
                if (await _productBrandService.IsExist(request.Name))
                {
                    return BadRequest(new { isSuccess = true, StatusCode = "400", Status = "Bad Request", Message = "Already Exist This Name", Data = validationResult.Errors }); ;
                }
                string token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

                var isAdded = await _productBrandService.Create(request, token);

                return isAdded ? Ok(new { isSuccess = true, StatusCode = "200", Status = "Ok", Message = "Data Create Succesfuly", Data = request })
                               : BadRequest(new { isSuccess = false, StatusCode = "400", Status = "Bad Request", Message = "Error in Request Object", Data = request });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
        [HttpGet("Brands")]
        public async Task<IActionResult> GetAllBrand([FromQuery]int page , [FromQuery]int pageSize)
        {
            try
            {
                var listOfBrand = await _productBrandService.GetAllBrand(page , pageSize);

                return listOfBrand is null ? NotFound(new { isSuccess = true, StatusCode = "404", Status = "Not Found", Message = "There is no  data", Data = listOfBrand }) 
                                           : Ok(new { isSuccess = true, StatusCode = "200", Status = "Ok", Message = "Data Retrived Succesfuly", Data = listOfBrand });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
           

        }
    }
}
