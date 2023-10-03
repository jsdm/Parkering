using CommunicationService.Models;
using CommunicationService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CommunicationService.Controllers
{
    [Route("api/sendSms")]
    [ApiController]
    public class SmsController : ControllerBase
    {
        private readonly ILogger<SmsController> _logger;
        private readonly ISmsSendApiService _smsSendApiService;
        public SmsController(ILogger<SmsController> logger, ISmsSendApiService smsSendApiService)
        {
            _logger = logger;
            _smsSendApiService = smsSendApiService;
        }
        [HttpPost("{phoneNumber}")]
        public async Task<IActionResult> SendSms(string phoneNumber)
        {
            string response = await _smsSendApiService.SendSmsAsync(phoneNumber);
            return Ok(response);
        }
    }
}
