using IMS.ClientEntity.ProductRequest;
using IMS.ClientEntity.shopRack;
using IMS.Service.productBrand;
using IMS.Service.shopRack;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMS.API.Controllers
{
    [Route("api/")]
    [ApiController]
    [Authorize]
    public class ShopRackController : ControllerBase
    {
        private readonly IShopRackService _shopRackService;
        public ShopRackController(IShopRackService shopRackService)
        {
            _shopRackService = shopRackService;

        }

        [HttpPost("shopracks")]
        public async Task<IActionResult> ShopRackCreate([FromBody] ShopRackRequest request)
        {
            try
            {
                string token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

                var isAdded = await _shopRackService.Create(request, token);

                return isAdded ? Ok(new { isSuccess = true, StatusCode = "200", Status = "Ok", Message = "Data Create Succesfuly", Data = request })
                               : BadRequest(new { isSuccess = true, StatusCode = "400", Status = "Bad Request", Message = "Error in Request Object", Data = request });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
        [HttpGet("shopracks")]
        public async Task<IActionResult> GetAllBrand([FromQuery] int page, [FromQuery] int pageSize)
        {
            try
            {
                var listOfBrand = await _shopRackService.GetAll(page, pageSize);

                return listOfBrand is null ? NotFound(new { isSuccess = true, StatusCode = "404", Status = "Not Found", Message = "There is no  data", Data = listOfBrand })
                                           : Ok(new { isSuccess = true, StatusCode = "200", Status = "Ok", Message = "Data Retrived Succesfuly", Data = listOfBrand });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
    }
}

