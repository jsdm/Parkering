using CommunicationService.Models;
using System.Text;
using System.Text.Json;
using System.Net.Http.Json;

namespace CommunicationService.Services
{
    public class EmailSendApiService : IEmailSendApiService
    {
        private readonly IConfiguration _configuration;
        private string url;
        public static HttpClient _httpClient= new HttpClient();
        public EmailSendApiService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<string> SendEmailAsync(string emailAddress)
        {
            Email email = new Email()
            {
                receiver = emailAddress,
                message = "Din parkering er begyndt",
                subject = "Parkering Startet",
                html = "<h1>Parkering.dk</h1>\n<h3>Din parkering er nu startet!</h3>"
            };
            using HttpResponseMessage response = await _httpClient.PostAsJsonAsync(
                _configuration.GetValue<string>("emailUrl"), new Email()
                {
                    receiver = emailAddress,
                    message = "Din parkering er begyndt",
                    subject = "Parkering Startet",
                    html = "<h1>Parkering.dk</h1>\n<h3>Din parkering er nu startet!</h3>"
                });
            //response.EnsureSuccessStatusCode();
            string emailSent = await response.Content.ReadAsStringAsync();
            return emailSent;
        }
    }
}
