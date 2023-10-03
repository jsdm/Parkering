using CommunicationService.Models;

namespace CommunicationService.Services
{
    public interface ISmsSendApiService
    {
        Task<string> SendSmsAsync(string phoneNumber);
    }
}
