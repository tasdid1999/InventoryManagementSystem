using IMS.API.Validator;
using IMS.ClientEntity.shopToshopTransfer;
using IMS.Service.shopToShopTransfer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMS.API.Controllers
{
    [Route("api/")]
    [ApiController]
    [Authorize]
    public class ShopToShopTransferController : ControllerBase
    {
        private readonly IShopToShopTransferService _stsService;
        private readonly ShopToShopTransferValidator _stsValidator;

        public ShopToShopTransferController(IShopToShopTransferService stsService, ShopToShopTransferValidator stsValidator)
        {
            _stsService = stsService;
            _stsValidator = stsValidator;
        }
        [HttpPost("shopToShopTransfer")]
        public async Task<IActionResult> Create([FromBody]ShopToShopTransferRequest request)
        {
            try
            {
                var validationResult = _stsValidator.Validate(request);

                if(!validationResult.IsValid)
                {
                    return BadRequest(new { isSuccess = false, StatusCode = "400", Status = "Bad Request", Message = "Error in Request Object", Data = validationResult.Errors });
                }
                string token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

                var isAdded = await _stsService.Create(request,token);
                return isAdded ? Ok(new { isSuccess = true, StatusCode = "200", Status = "Ok", Message = "Data Create Succesfuly", Data = request })
                                              : BadRequest(new { isSuccess = false, StatusCode = "400", Status = "Bad Request", Message = "Error in Request Object", Data = request });
            }
            catch (Exception ex)
            {
                return BadRequest(new { isSuccess = false, StatusCode = "400", Status = "Bad Request", Message = "Error in Request Object", Data = ex.Message });
            }
        }

        [HttpGet("shopToShopTransfer")]
        public async Task<IActionResult> GetAll([FromQuery]int page , [FromQuery]int pageSize)
        {
            try
            {

                var listOfShopTransfer = await _stsService.GetAll(page, pageSize);
                return listOfShopTransfer is not null ? Ok(new { isSuccess = true, StatusCode = "200", Status = "Ok", Message = "Data Retrived Succesfuly", Data = listOfShopTransfer })
                                              : BadRequest(new { isSuccess = false, StatusCode = "404", Status = "Not Found", Message = "There is no data", Data = listOfShopTransfer });
            }
            catch (Exception ex)
            {
                return BadRequest(new { isSuccess = false, StatusCode = "400", Status = "Bad Request", Message = "Error in Request Object", Data = ex.Message });
            }
        }
        [HttpGet("shopToShopTransfer/{id}")]
        public async Task<IActionResult> GetById([FromRoute]int id)
        {
            try
            {

                var ShopTransfer = await _stsService.GetById(id);
                return ShopTransfer is not null ? Ok(new { isSuccess = true, StatusCode = "200", Status = "Ok", Message = "Data Retrived Succesfuly", Data = ShopTransfer })
                                              : BadRequest(new { isSuccess = false, StatusCode = "404", Status = "Not Found", Message = "There is no data", Data = ShopTransfer });
            }
            catch (Exception ex)
            {
                return BadRequest(new { isSuccess = false, StatusCode = "400", Status = "Bad Request", Message = "Error in Request Object", Data = ex.Message });
            }
        }

    }
}
