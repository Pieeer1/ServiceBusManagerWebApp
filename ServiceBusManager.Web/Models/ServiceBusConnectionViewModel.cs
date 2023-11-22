using Azure.Messaging.ServiceBus;

namespace ServiceBusManager.Web.Models
{
    public class ServiceBusConnectionViewModel
    {
        public ServiceBusConnectionViewModel(string name, ServiceBusTransportType transportType, string fullyQualifiedNamespace, string identifier)
        {
            Name = name;
            TransportType = transportType;
            FullyQualifiedNamespace = fullyQualifiedNamespace;
            Identifier = identifier;
        }

        public string Name { get; private set; }
        public ServiceBusTransportType TransportType { get; private set; }
        public string FullyQualifiedNamespace { get; private set; }
        public string Identifier { get; private set; }
    }
}
