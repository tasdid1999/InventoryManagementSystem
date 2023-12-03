using IMS.API.Validator;
using IMS.ClientEntity.Requsition;
using IMS.Service.requsition;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;

namespace IMS.API.Controllers
{
    [Route("api/")]
    [ApiController]
    [Authorize]
    public class RequsitionController : ControllerBase
    {
        private readonly IRequsitionService _requsitionService;
        private readonly RequisitionValidator _requisitionValidator;
        public RequsitionController(IRequsitionService requsitionService, RequisitionValidator requisitionValidator = null)
        {
            _requsitionService = requsitionService;
            _requisitionValidator = requisitionValidator;
        }
        [HttpPost("requisitions")]
        public async Task<IActionResult> CreateRequsition([FromBody] RequsitionRequest request)
        {

            try
            {

                var validationResult = _requisitionValidator.Validate(request);

                if (!validationResult.IsValid)
                {
                    return BadRequest(new { isSuccess = false, StatusCode = "400", Status = "Bad Request", Message = "Error in Request Object", Data = validationResult.Errors });
                }

                string token = HttpContext.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");

                var isAdded = await _requsitionService.Create(request, token);

                return isAdded ? Ok(new { isSuccess = true, StatusCode = "200", Status = "Ok", Message = "Data Create Succesfuly", Data = request })
                               : BadRequest(new { isSuccess = false, StatusCode = "400", Status = "Bad Request", Message = "Error in Request Object", Data = request });
            }
            catch (Exception ex)
            {
                return BadRequest(new { isSuccess = false, StatusCode = "400", Status = "Bad Request", Message = "Error in Request Object", Data = ex.Message });
            }
        }

        [HttpGet("requisitions")]
        public async Task<IActionResult> GetAllRequsition([FromQuery] int page, [FromQuery] int pageSize)
        {
            try
            {
                var listOfRequsition = await _requsitionService.GetAll(page, pageSize);

                return listOfRequsition is null ? NotFound(new { isSuccess = false, StatusCode = "404", Status = "Not Found", Message = "There is no  data", Data = listOfRequsition })
                                              : Ok(new { isSuccess = true, StatusCode = "200", Status = "Ok", Message = "Data Retrived Succesfuly", Data = listOfRequsition });
            }
            catch(Exception ex)
            {
                return BadRequest(new { isSuccess = false, StatusCode = "400", Status = "Bad Request", Message = "Request is wrong", Data = ex.Message });
            }
        }
        [HttpGet("requisitions/{id:int}")]
        public async Task<IActionResult> GetRequsitionById([FromRoute] int id)
        {
            try
            {
                var requsition = await _requsitionService.GetById(id);

                return requsition is null ? NotFound(new { isSuccess = true, StatusCode = "404", Status = "Not Found", Message = "There is no  data", Data = requsition })
                                              : Ok(new { isSuccess = true, StatusCode = "200", Status = "Ok", Message = "Data Retrived Succesfuly", Data = requsition });
            }
            catch (Exception ex)
            {
                return BadRequest(new { isSuccess = false, StatusCode = "400", Status = "Bad Request", Message = "Request is wrong", Data = ex.Message });
            }

        }
    }
}
