using CommunicationService.Models;
using System.Text;
using System.Text.Json;
using System.Net.Http.Json;

namespace CommunicationService.Services
{
    public class EmailSendApiService:IEmailSendApiService
    {
        private readonly string url = "https://twilioproxy.azurewebsites.net/api/SendEmail?code=qMTJzZtnKGD4c0LgyYHyepoT7VdFOir1Wig9yrU6LeQLAzFuCJeiWw==";
        public static HttpClient _httpClient= new HttpClient();
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
                url, new Email()
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
