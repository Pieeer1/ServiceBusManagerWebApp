using System.ComponentModel.DataAnnotations;

namespace ServiceBusManager.Data.Models
{
    public class ReceiveMessageForm
    {
        [Required]
        public string TopicName { get; set; } = null!;
        [Required]
        public string SubscriptionName { get; set; } = null!;
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int MessageCount { get; set; }
    }
}
