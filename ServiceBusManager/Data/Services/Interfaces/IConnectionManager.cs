using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Administration;
using ServiceBusManager.Data.Models;

namespace ServiceBusManager.Data.Services.Interfaces
{
    public interface IConnectionManager
    {
        bool AddConnection(AddConnectionForm addConnectionForm, out string? error);
        (ServiceBusClient client, ServiceBusAdministrationClient admin) GetConnectionByName(string key);
        IEnumerable<ServiceBusConnectionViewModel> GetServiceBusConnections();
        void RemoveConnection(string name);
    }
}
