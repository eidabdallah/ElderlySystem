using ElderlySystem.BLL.Service.Elderly;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElderlySystem.PL.Areas.Admin.Controller
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ElderlyController : ControllerBase
    {
        private readonly IElderlyService _service;

        public ElderlyController(IElderlyService elderlyService)
        {
            _service = elderlyService;
        }
        [HttpGet("")]
        public async Task<IActionResult> GetAllElderlyRegisterRequest()
        {
            var result = await _service.GetAllElderlyRegisterRequestAsync();
            return Ok(new { message = result.Message , Ederlies = result.Data});
        }
        // get ederly details ( with sponsor ) 
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEderlyDetails(int id)
        {
            var result = await _service.GetEderlyDetailsAsync(id);
            if (!result.Success)
            {
                return BadRequest(new { message = result.Message });
            }
            return Ok(new { message = result.Message, Elderly = result.Data });
        }
        // change status : 
        [HttpPatch("{id}")]
        public async Task<IActionResult> ChangeStatusElderly(int id)
        {
            var result = await _service.ChangeStatusElderlyAsync(id);
            if (!result.Success)
            {
                return BadRequest(new { message = result.Message });
            }
            return Ok(new { message = result.Message});
        }
    }
}
