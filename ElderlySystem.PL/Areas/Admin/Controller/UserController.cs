using EderlySystem.DAL.Enums;
using ElderlySystem.BLL.Services.User;
using ElderlySystem.DAL.DTO.Request.User;
using ElderlySystem.DAL.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ElderlySystem.PL.Areas.Admin.Controller
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpGet("All")]
        public async Task<IActionResult> GetAllUserWithFilter([FromQuery] string? status, [FromQuery] string? role)
        {
            Status? userStatus = null;
            if (!string.IsNullOrEmpty(status) && Enum.TryParse<Status>(status, true, out var parsedStatus))
            {
                userStatus = parsedStatus;
            }

            Role? userRole = null;
            if (!string.IsNullOrEmpty(role) && Enum.TryParse<Role>(role, true, out var parsedRole))
            {
                userRole = parsedRole;
            }

            var result = await _userService.GetAllUserWithFilterAsync(userStatus, userRole);

            if (result.Data is null)
                return Ok(new { message = result.Message });

            return Ok(new { message = result.Message, users = result.Data });
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetByIdForAdmin([FromRoute] string userId)
        {
            var user = await _userService.GetByIdAsync(userId!);
            if (!user.Success)
            {
                return BadRequest(new { message = user.Message });
            }
            return Ok(new { message = user.Message, user = user.Data });
        }
        [Authorize(Roles = "Nurse,Admin,Sponsor,Secretary")]
        [HttpGet("")]
        public async Task<IActionResult> GetByIdForUser()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userService.GetByIdAsync(userId!);
            if (!user.Success)
            {
                return BadRequest(new { message = user.Message });
            }
            return Ok(new { message = user.Message, user = user.Data });

        }
        [HttpPatch("Change-Role/{id}")]
        public async Task<IActionResult> ChangeRole([FromRoute] string id, [FromBody] ChangeRoleRequest request)
        {
            var result = await _userService.ChangeUserRoleAsync(id, request);
            if (!result.Success)
            {
                return BadRequest(new { message = result.Message });
            }
            return Ok(new { message = result.Message });
        }
        [HttpPatch("change-status/{userId}")]
        public async Task<IActionResult> ChangeStatusToggle([FromRoute] string userId)
        {
            var result = await _userService.ChangeStatusToggleAsync(userId);
            if (!result)
            {
                return NotFound(new { Message = "المستخدم غير موجود او لم تتم تغيير الحالة" });
            }
            return Ok(new { Message = "تم تغيير الحالة بنجاح" });

        }
        [HttpPatch("block/{id}")]
        public async Task<IActionResult> BlockUser([FromRoute] string id, [FromBody] BlockRequestDTO request)
        {
            var result = await _userService.BlockUserAsync(id, request.days);
            if (!result)
            {
                return NotFound();
            }
            return Ok(new { message = "blocked user successfully" });
        }
        [HttpPatch("unblock/{id}")]
        public async Task<IActionResult> UnblockUser([FromRoute] string id)
        {
            var result = await _userService.UnBlockUserAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return Ok(new { message = "UnBlocked user successfully" });
        }
        [HttpPatch("isBlock/{id}")]
        public async Task<IActionResult> IsBlockUser([FromRoute] string id)
        {
            var isBlocked = await _userService.IsBlockedAsync(id);
            return Ok(isBlocked);
        }
    }
}
