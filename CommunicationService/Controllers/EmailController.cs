using CommunicationService.Models;
using CommunicationService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace CommunicationService.Controllers
{
    [Route("api/sendCom")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly ILogger<EmailController> _logger;
        private readonly IEmailSendApiService _emailSendApiService;
        public EmailController(ILogger<EmailController> logger, IEmailSendApiService emailSendApiService)
        {
            _logger = logger;
            _emailSendApiService = emailSendApiService;
        }
        [HttpPost("{emailAddress}")]
        public async Task<IActionResult> SendMail(string emailAddress)
        {
            string response = await _emailSendApiService.SendEmailAsync(emailAddress);
            return Ok(response);
        }


        //[HttpGet("{PhoneNumber:int}")]
    }
}
