using IMS.ClientEntity.shopRack;
using IMS.ClientEntity.shopRow;
using IMS.Service.shopRack;
using IMS.Service.shopRow;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMS.API.Controllers
{
    [Route("api/")]
    [ApiController]
    [Authorize]
    public class ShopRowController : ControllerBase
    {
        private readonly IShopRowService _shopRowService;
        public ShopRowController(IShopRowService shopRowService)
        {
            _shopRowService = shopRowService;

        }

        [HttpPost("shoprows")]
        public async Task<IActionResult> ShopRowCreate([FromBody] ShopRowRequest request)
        {
            try
            {
                string token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

                var isAdded = await _shopRowService.Create(request, token);

                return isAdded ? Ok(new { isSuccess = true, StatusCode = "200", Status = "Ok", Message = "Data Create Succesfuly", Data = request })
                               : BadRequest(new { isSuccess = true, StatusCode = "400", Status = "Bad Request", Message = "Error in Request Object", Data = request });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
        [HttpGet("shoprows")]
        public async Task<IActionResult> GetAllShopRow([FromQuery] int page, [FromQuery] int pageSize)
        {
            try
            {
                var listOfShopRow = await _shopRowService.GetAll(page, pageSize);

                return listOfShopRow is null ? NotFound(new { isSuccess = true, StatusCode = "404", Status = "Not Found", Message = "There is no  data", Data = listOfShopRow })
                                           : Ok(new { isSuccess = true, StatusCode = "200", Status = "Ok", Message = "Data Retrived Succesfuly", Data = listOfShopRow });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
    }
}

