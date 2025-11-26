using ElderlySystem.BLL.Service.Room;
using ElderlySystem.DAL.DTO.Request.Room;
using ElderlySystem.DAL.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElderlySystem.PL.Areas.Admin.Controller
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _service;

        public RoomController(IRoomService service)
        {
            _service = service;
        }
        [HttpPost("")]
        public async Task<IActionResult> AddRoom([FromForm] RoomCreateRequest request)
        {
            var result = await _service.AddRoomAsync(request);
            if (!result.Success)
            {
                return BadRequest(new { message = result.Message });
            }
            return Ok(new { message = result.Message});
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateRoom([FromRoute] int id ,[FromBody] UpdateRoomRequest request)
        {
            var room = await _service.UpdateRoomAsync(request , id);
            if (!room.Success) {
                return BadRequest(new { message = room.Message });
            }
            return Ok(new { message = room.Message });
        }
        [HttpPatch("toggle-status/{RoomId}")]
        public async Task<IActionResult> ToggleStatus([FromRoute] int RoomId)
        {
            var result = await _service.ToggleRoomStatusAsync(RoomId);

            if (!result.Success)
                return BadRequest(new { message = result.Message });

            return Ok(new { message = result.Message });
        }
        [HttpPatch("Change-imageRoom/{RoomId}")]
        public async Task<IActionResult> ChangeImageRoom([FromRoute] int RoomId , [FromForm] ImageRoomRequest request)
        {
            var result = await _service.ChangeImageRoomAsync(RoomId , request);

            if (!result.Success)
                return BadRequest(new { message = result.Message });

            return Ok(new { message = result.Message });
        }
    }
}
 