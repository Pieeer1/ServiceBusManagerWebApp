using System.ComponentModel.DataAnnotations;

namespace ServiceBusManager.Data.Models
{
    public class AddConnectionForm
    {
        [Required]
        public string Name { get; set; } = null!;

        [Required]
        // TODO - add regex here
        public string ConnectionString { get; set; } = null!;

    }
}
