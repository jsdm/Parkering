namespace CommunicationService.Models
{
    public class Sms
    {
        public string Receiver { get; set; }
        public string Key { get; set; }
        public string Message { get; set; }
    }
}
//receiver - telefonnummeret på modtageren. Skal starte med +45
//key - din unikke nøgle som giver dig adgang til at sende til din egen telefon
//message - den besked der skal sendes