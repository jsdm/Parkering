namespace CommunicationService.Models
{
    public class Email
    {
        public string receiver { get; set; }
        public string message { get; set; }
        public string subject { get; set; }
        public string? html { get; set; }
    }
}
