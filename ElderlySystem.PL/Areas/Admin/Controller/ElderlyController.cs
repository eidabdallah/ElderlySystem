using ElderlySystem.BLL.Service.Sponsor;
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
        private readonly ISponsorService _sponsorService;
        public ElderlyController(ISponsorService sponsorService)
        {
            _sponsorService = sponsorService;
        }
    }
}
