using System.ComponentModel.DataAnnotations;

namespace ServiceBusManager.Data.Models
{
    public class SendMessageForm
    {
        [Required(ErrorMessage = "Message Is Required.")]
        public string MessageText { get; set; } = null!;

        public Dictionary<string, string> MessageProperties { get; set; } = new Dictionary<string, string>();
    }
}
