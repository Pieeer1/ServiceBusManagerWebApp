namespace ServiceBusManager.Data.Models
{
    public class ServiceBusConnectionViewModel
    {
        public ServiceBusConnectionViewModel(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

    }
}
