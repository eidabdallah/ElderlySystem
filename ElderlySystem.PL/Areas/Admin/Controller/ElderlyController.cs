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
        private readonly IElderlyService _elderlyService;

        public ElderlyController(IElderlyService elderlyService)
        {
            _elderlyService = elderlyService;
        }

    }
}
