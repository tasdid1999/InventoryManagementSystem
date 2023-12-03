using FluentValidation;
using IMS.API.Validator;
using IMS.ClientEntity;
using IMS.ClientEntity.ProductRequest;
using IMS.ClientEntity.purchase;
using IMS.Service.purchase;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PurchaseController : ControllerBase
    {

        private readonly IPurchaseService _purchaseService;
        private readonly PurchaseValidator _purchaseValidator;
       
        public PurchaseController(IPurchaseService purchaseService, PurchaseValidator purchaseValidator)
        {
            _purchaseService = purchaseService;
            _purchaseValidator = purchaseValidator;
           
        }
        [HttpPost("purchase/{requisitionId}")]
        public async Task<IActionResult> PurchaseCreate([FromBody]PurchaseRequest request, [FromRoute]int requisitionId)
        {

            try
            {
                var validationResult = _purchaseValidator.Validate(request);

                if (!validationResult.IsValid)
                {
                    return BadRequest(new { isSuccess = false, StatusCode = "400", Status = "Bad Request", Message = "Error in Request Object", Data = validationResult.Errors });
                }
                string token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
                var isAdded = await _purchaseService.Create(request,requisitionId,token);

                return isAdded ? Ok(new { isSuccess = true, StatusCode = "200", Status = "Ok", Message = "Data Create Succesfuly", Data = request })
                                : BadRequest(new { isSuccess = false, StatusCode = "400", Status = "Bad Request", Message = "Error in Request Object", Data = request });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
        [HttpGet("purchase")]
        public async Task<IActionResult> PurchaseCreate([FromQuery]int page , [FromQuery] int pageSize)
        {

            try
            {
                var listOfPurchase = await _purchaseService.GetAll(page, pageSize);

                return listOfPurchase is not null ? Ok(new { isSuccess = true, StatusCode = "200", Status = "Ok", Message = "Data Retrived Succesfuly", Data = listOfPurchase })
                                : NotFound(new { isSuccess = false, StatusCode = "404", Status = "Data Not Found", Data = listOfPurchase });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }
    }
}
