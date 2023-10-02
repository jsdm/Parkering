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
// --------------------------------------------------------------------------------------------------------------------------------------------------------------
//Email - servicen findes på denne adresse: https://twilioproxy.azurewebsites.net/api/SendEmail?code=qMTJzZtnKGD4c0LgyYHyepoT7VdFOir1Wig9yrU6LeQLAzFuCJeiWw==

//Den modtager data med post. Det skal være et json-objekt med følgende værdier

//receiver - modtagerens email-adresse
//message - beskedens indhold
//subject - beskedes titel
//html - besked formatteret i html (valgfrit)
//Der er følgende begrænsninger af servicen:

//Alle e-mails sendes fra min adresse (ktlh@smartlearning.dk)
//Du kan kun sende til din smartlearning eller cphbusiness-adresse.