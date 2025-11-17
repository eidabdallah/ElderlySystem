using ElderlySystem.BLL.Services.Authentication;
using ElderlySystem.DAL.DTO.Request.Auth;
using Microsoft.AspNetCore.Mvc;

namespace ElderlySystem.PL.Areas.Identity.Controller
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Identity")]
    public class AccountController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;

        public AccountController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var result = await _authenticationService.RegisterAsync(request , Request);
            if (!result.Success)
            {
                return BadRequest(new { message = result.Message });
            }
            return Ok(new { message = result.Message });
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var result = await _authenticationService.LoginAsync(request);

            if (!result.Success)
                return BadRequest(new { message = result.Message });

            if (result.Data != null)
                return Ok(new { message = result.Message, token = result.Data });
            return Ok(new { message = result.Message });
        }
        [HttpGet("ConfirmEmail")]
        public async Task<IActionResult> ConfirmEmail([FromQuery] string token, [FromQuery] string userId)
        {
            bool isConfirmed = await _authenticationService.ConfirmEmail(token, userId);

            string filePath = Path.Combine(Directory.GetCurrentDirectory(),
                "wwwroot", "pages", isConfirmed ? "confirm-success.html" : "confirm-failed.html");

            string htmlContent = await System.IO.File.ReadAllTextAsync(filePath);

            return new ContentResult
            {
                Content = htmlContent,
                ContentType = "text/html",
                StatusCode = isConfirmed ? 200 : 400
            };
        }
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            var result = await _authenticationService.ForgotPassword(request);
            if (!result.Success)
                return BadRequest(new { message = result.Message });
            return Ok(new { message = result.Message });
        }
        [HttpPatch("reset-password")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequest request)
        {
            var result = await _authenticationService.ResetPassword(request);
            if (!result.Success)
                return BadRequest(new { message = result.Message });
            return Ok(new { message = result.Message });
        }
    }
}
