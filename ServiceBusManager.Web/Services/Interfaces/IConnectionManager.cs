using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Administration;
using ServiceBusManager.Web.Models;

namespace ServiceBusManager.Web.Services.Interfaces
{
    public interface IConnectionManager
    {
        HashSet<Type> DistinctRefreshers { get; }

        event EventHandler? OnRefresh;

        bool AddConnection(AddConnectionForm addConnectionForm, out string? error);
        (ServiceBusClient client, ServiceBusAdministrationClient admin) GetConnectionByName(string key);
        IEnumerable<ServiceBusConnectionViewModel> GetServiceBusConnections();
        void RefreshRequested();
        void RemoveConnection(string name);
    }
}
