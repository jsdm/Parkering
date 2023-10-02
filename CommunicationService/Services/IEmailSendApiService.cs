using CommunicationService.Models;

namespace CommunicationService.Services
{
    public interface IEmailSendApiService
    {
        Task<string> SendEmailAsync(string emailAddress);
    }
}
