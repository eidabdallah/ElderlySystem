using ElderlySystem.BLL.Service.Sponsor;
using ElderlySystem.DAL.DTO.Request.ElderlySponsor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ElderlySystem.PL.Areas.Sponsor.Controller
{
    [Route("api/[area]/[controller]")]
    [ApiController]
    [Area("Sponsor")]
    [Authorize(Roles = "Sponsor")]
    public class ElderlyController : ControllerBase
    {
        private readonly ISponsorService _sponsorService;

        public ElderlyController(ISponsorService sponsorService)
        {
            _sponsorService = sponsorService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllElderlyBySponsor()
        {
            var SponsorId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _sponsorService.GetEldersBySponsorIdAsync(SponsorId!);
            if (result.Data is null)
                return Ok(new { message = result.Message });
            return Ok(new { message = result.Message, users = result.Data });
        }
        [HttpPost]
        public async Task<IActionResult> AddElderlyBySponsor([FromForm] ElderlyRegisterRequest request)
        {
            var SponsorId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _sponsorService.AddElderlyBySponsorAsync(SponsorId!, request);
            if (!result.Success)
            {
                return NotFound(new { message = result.Message });
            }
            return Ok(new { message = result.Message });
        }
        [HttpGet("all")]
        public async Task<IActionResult> GetAllElderly()
        {
            var result = await _sponsorService.GetAllElderlyAsync();

            if (result.Data is null)
                return Ok(new { message = result.Message });

            return Ok(new { message = result.Message, elderly = result.Data });
        }
        [HttpPost("link")]
        public async Task<IActionResult> LinkElderlyToSponsor([FromBody] LinkElderlySponsorRequest request)
        {
            var sponsorId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var result = await _sponsorService.LinkSponsorToElderlyAsync(sponsorId!, request);

            if (!result.Success)
                return BadRequest(new { message = result.Message });

            return Ok(new { message = result.Message });
        }

    }
}
