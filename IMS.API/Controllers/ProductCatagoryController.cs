using Azure.Core;
using IMS.API.Validator;
using IMS.ClientEntity.ProductRequest;
using IMS.Service.productBrand;
using IMS.Service.productCatagory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMS.API.Controllers
{
    [Route("api/")]
    [ApiController]
    //[Authorize]
    public class ProductCatagoryController : ControllerBase
    {
        private readonly IProductCatagoryService _productCatagoryService;
        private readonly ProductCatagoryValidator _catagoryValidator;

        public ProductCatagoryController(IProductCatagoryService productCatagoryService, ProductCatagoryValidator catagoryValidator)
        {
            _productCatagoryService = productCatagoryService;
            _catagoryValidator = catagoryValidator;
        }

        [HttpPost("catagories")]
        public async Task<IActionResult> CreateCatagory([FromBody]ProductCatagoryRequest request)
        {
            try
            {
                var validationResult = _catagoryValidator.Validate(request);


                if (!validationResult.IsValid)
                {
                    return BadRequest(new { isSuccess = false, StatusCode = "400", Status = "Bad Request", Message = "Error in Request Object", Data = validationResult.Errors });
                }
                if (await _productCatagoryService.IsExist(request.Name))
                {
                    return BadRequest(new { isSuccess = false, StatusCode = "400", Status = "Bad Request", Message = "Already Exist this Name", Data = request });
                }
                string token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

                var isAdded = await _productCatagoryService.Create(request,token);

                return isAdded ? Ok(new {isSuccess = true , StatusCode = "200" , Status = "Ok", Message = "Data Create Succesfuly",Data = request})
                               : BadRequest(new { isSuccess = false, StatusCode = "400", Status = "Bad Request", Message = "Error in Request Object", Data = request });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet("catagories")]
        public async Task<IActionResult> GetAllCatagory([FromQuery]int page , [FromQuery]int pageSize)
        {
            try
            {
                var listOfCatagory = await _productCatagoryService.GetAll(page , pageSize);

                return listOfCatagory is null ? NotFound(new { isSuccess = true, StatusCode = "404", Status = "Not Found", Message = "There is no  data", Data = listOfCatagory })
                                           : Ok(new { isSuccess = true, StatusCode = "200", Status = "Ok", Message = "Data Retrived Succesfuly", Data = listOfCatagory });
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
