using ServiceBusManager.Web.Models.Shared;
using System.ComponentModel.DataAnnotations;

namespace ServiceBusManager.Web.Models.Validators
{
    public class CheckEqualStrings : ValidationAttribute
    {

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (!(value is MutableEqualStringPair mut) || (mut.Item1 != mut.Item2))
            {
                return new ValidationResult(ErrorMessage ?? "Values are not Equal");
            }

            return ValidationResult.Success;
        }
    }
}
