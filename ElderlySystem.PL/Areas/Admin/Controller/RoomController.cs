using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElderlySystem.PL.Areas.Admin.Controller
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Role")]
    [Authorize(Roles = "Admin")]
    public class RoomController : ControllerBase
    {
        /*[HttpPost("")]
        public async Task<IActionResult> AddRoom([FromForm] )
        {
        }*/
    }
}
 