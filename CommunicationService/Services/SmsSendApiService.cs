using CommunicationService.Models;
namespace CommunicationService.Services
{
    public class SmsSendApiService : ISmsSendApiService
{
    private readonly IConfiguration _config;
    private static HttpClient _httpClient = new HttpClient();
    public SmsSendApiService(IConfiguration config)
    {
        _config = config;
    }
    public async Task<string> SendSmsAsync(string phoneNumber)
    {
        var smsKey = _config["SmsApiKey"];
        using HttpResponseMessage response = await _httpClient.PostAsJsonAsync(
            _config.GetValue<string>("SmsUrl"), new Sms()
            {
                Receiver = phoneNumber,
                Key = smsKey,
                Message = "Parkering.dk\nDin parkering er nu startet!\n"
            });
        string smsSent = await response.Content.ReadAsStringAsync();
        return smsSent;
        }
    }
}
