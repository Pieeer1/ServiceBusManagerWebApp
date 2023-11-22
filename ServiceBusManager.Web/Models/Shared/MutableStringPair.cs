using System.ComponentModel.DataAnnotations;

namespace ServiceBusManager.Web.Models.Shared
{
    public class MutableEqualStringPair
    {
        public string? Item1 { get; set; }
        [Required(ErrorMessage = "Invalid: Empty Values not Allowed")]
        public string? Item2 { get; set; }

    }
}
