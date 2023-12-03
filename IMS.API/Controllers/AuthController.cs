using Ecom.API.Validator;
using Ecom.Service.User;
using IMS.ClientEntity.Auth;
using IMS.Service.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMS.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;
        private readonly LoginValidator _loginValidator;
        private readonly RegisterValidator _registerValidator;
        
        public AuthController(IUserService userService, IAuthService authService, IConfiguration configuration, LoginValidator loginValidator, RegisterValidator registerValidator)
        {
            _userService = userService;
            _authService = authService;
            _configuration = configuration;
            _loginValidator = loginValidator;
            _registerValidator = registerValidator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest user)
        {
            try
            {
               

                var validationResult = _registerValidator.Validate(user);

                if (!validationResult.IsValid)
                {
                    return BadRequest(validationResult.Errors);
                }

                if (!await _userService.IsRoleExist(user.Role))
                {
                    return BadRequest(new { IsSucces = false, StatusCode = "400", Status = "Bad Request", Message = "Role doesn't Exisit" });
                }

                if (await _userService.IsEmailExistAsync(user.Email))
                {
                    return BadRequest(new { IsSuccess = false, Message = "This Email Already Registered." });
                }

                var isRegistered = await _authService.RegisterAsync(user);

                if (isRegistered)
                {
                    return Ok(new { IsSuccess = true, Message = "SuccesFully Registered" });
                }

                return BadRequest(new { IsSuccess = false, Message = "Internal Server Issue" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginRequest user)
        {

            try
            {
                var validationResult = _loginValidator.Validate(user);

                if (!validationResult.IsValid)
                {

                    return BadRequest(validationResult.Errors);
                }

                if (!await _userService.IsUserExistAsync(user.Email, user.Password))
                {
                    return BadRequest(new { IsSuccess = false, Message = "Wrong Credential", Token = "" });
                }

                var isLogInSucces = await _authService.LoginAsync(user);

                if (isLogInSucces)
                {
                    var userForToken = await _userService.GetUserForTokenAsync(user.Email);
                    userForToken.SecretKey = _configuration.GetValue<string>("Jwt:SecretKey") ?? throw new Exception("there is no Secret Key");
                    var token = _authService.GetJwtToken(userForToken);

                    return Ok(new { IsSuccess = true, Message = "Login Succesful", Token = token });

                }

                return BadRequest(new { IsSuccess = false, Message = "Internal Server Issue!", Token = "" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}

