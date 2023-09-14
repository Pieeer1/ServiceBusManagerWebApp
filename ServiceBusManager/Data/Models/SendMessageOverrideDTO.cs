namespace ServiceBusManager.Data.Models
{
    public class SendMessageOverrideDTO
    {
        public string Message { get; set; } = string.Empty;
        public Dictionary<string, string> ApplicationProperties { get; set; } = new Dictionary<string, string>();
    }
}
