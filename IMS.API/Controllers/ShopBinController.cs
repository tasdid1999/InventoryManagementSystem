using IMS.ClientEntity.shopBin;
using IMS.ClientEntity.shopRack;
using IMS.Service.shopBin;
using IMS.Service.shopRack;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMS.API.Controllers
{
    [Route("api/")]
    [ApiController]
    [Authorize]
    public class ShopBinController : ControllerBase
    {
        private readonly IShopBinService _shopBinService;
        public ShopBinController(IShopBinService shopBinService)
        {
            _shopBinService = shopBinService;

        }

        [HttpPost("shopbins")]
        public async Task<IActionResult> ShopBinCreate([FromBody] ShopBinRequest request)
        {
            try
            {
                string token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

                var isAdded = await _shopBinService.Create(request, token);

                return isAdded ? Ok(new { isSuccess = true, StatusCode = "200", Status = "Ok", Message = "Data Create Succesfuly", Data = request })
                               : BadRequest(new { isSuccess = true, StatusCode = "400", Status = "Bad Request", Message = "Error in Request Object", Data = request });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
        [HttpGet("shopbins")]
        public async Task<IActionResult> GetAllBin([FromQuery] int page, [FromQuery] int pageSize)
        {
            try
            {
                var listOfBrand = await _shopBinService.GetAll(page, pageSize);

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

