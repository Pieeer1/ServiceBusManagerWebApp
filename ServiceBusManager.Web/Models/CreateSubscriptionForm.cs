using System.ComponentModel.DataAnnotations;

namespace ServiceBusManager.Web.Models
{
    public class CreateSubscriptionForm
    {

        [Required]
        public string TopicName { get; set; } = null!;
        [Required(ErrorMessage = "Subscription Name is Required.")]
        public string SubscriptionName { get; set; } = null!;

        [Required(ErrorMessage = "Default Time to Live is Required.")]
        [RegularExpression(@"[0-9]{2}:[0-9]{2}:[0-9]{2}", ErrorMessage = "Timespan Must be in format (hours:minutes:seconds) IE: 48:30:00.")]
        public string DefaultTimeToLiveString { get; set; } = null!;
        public TimeSpan DefaultTimeToLive
        {
            get
            {
                TimeSpan.TryParse(DefaultTimeToLiveString, out TimeSpan result);
                return result;
            }
        }
    }
}
