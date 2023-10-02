using BiltypeService.Models;
using BiltypeService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BiltypeService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotorApiController : ControllerBase
    {
        private readonly ILogger<MotorApiController> _logger;
        private readonly IMotorApiService _motorApiService;
        public MotorApiController(ILogger<MotorApiController> logger, IMotorApiService motorApiService)
        {
            _logger = logger;
            _motorApiService = motorApiService;
        }
        [HttpGet("{registreringsNummer}")]
        public async Task<CarDescription> Get(string registreringsNummer)
        {
            return await _motorApiService.GetDescriptionAsync(registreringsNummer);
        }
    }
}
