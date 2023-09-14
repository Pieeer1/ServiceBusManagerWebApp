using System.ComponentModel.DataAnnotations;

namespace ServiceBusManager.Data.Models
{
    public class SendMessageForm
    {
        [Required(ErrorMessage = "Message Is Required.")]
        [MaxLength(131072 /*262144/sizeof(char)*/, ErrorMessage = "Max Message Size is 131072 Characters")]
        public string MessageText { get; set; } = null!;

        public Dictionary<string, string> MessageProperties { get; set; } = new Dictionary<string, string>();
    }
}
