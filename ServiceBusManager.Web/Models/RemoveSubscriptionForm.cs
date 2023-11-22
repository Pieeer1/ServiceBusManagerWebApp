using ServiceBusManager.Web.Models.Shared;
using ServiceBusManager.Web.Models.Validators;
using System.ComponentModel.DataAnnotations;

namespace ServiceBusManager.Web.Models
{
    public class RemoveSubscriptionForm
    {
        [Required]
        public string TopicName { get; set; } = null!;
        [Required(ErrorMessage = "Name is Required.")]
        [CheckEqualStrings]
        public MutableEqualStringPair SubscriptionName { get; set; } = new MutableEqualStringPair(); // TODO -- Refactor so Form is not green on invalid input. Caused by using the Item2 of the tuple as the value. Needs to be refactored entirely. See MutableEqualStringPair and CheckEqualStrings
    }
}
