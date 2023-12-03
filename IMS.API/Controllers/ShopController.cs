using IMS.API.Validator;
using IMS.ClientEntity.ProductRequest;
using IMS.ClientEntity.shop;
using IMS.Service.shop;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMS.API.Controllers
{
    [Route("api/")]
    [ApiController]
    [Authorize]
    public class ShopController : ControllerBase
    {
        private readonly IShopService _shopService;
        private readonly ShopValidator _shopValidator;
       
        public ShopController(IShopService shopService,ShopValidator shopValidator)
        {
            _shopService = shopService;
            _shopValidator = shopValidator;
           

        }

        [HttpGet("shops")]

        public async Task<IActionResult> GetAllShop([FromQuery] int page, [FromQuery] int pageSize)
        {
            try
            {
                var listOfShop = await _shopService.GetAll(page, pageSize);

                return listOfShop is null ? NotFound(new { isSuccess = true, StatusCode = "404", Status = "Not Found", Message = "There is no  data", Data = listOfShop })
                                           : Ok(new { isSuccess = true, StatusCode = "200", Status = "Ok", Message = "Data Retrived Succesfuly", Data = listOfShop });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost("shops")]
        public async Task<IActionResult> ShopCreate([FromBody] ShopRequest request)
        {
            try
            {
                var validationResult = _shopValidator.Validate(request);

                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult);
                }
                string token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

                var isAdded = await _shopService.Create(request,token);

                return isAdded ? Ok(new { isSuccess = true, StatusCode = "200", Status = "Ok", Message = "Data Create Succesfuly", Data = request })
                               : BadRequest(new { isSuccess = true, StatusCode = "400", Status = "Bad Request", Message = "Error in Request Object", Data = request });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
    }
}
