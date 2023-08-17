using ServiceBusManager.Data.Models;

namespace ServiceBusManager.Data.Services.Interfaces
{
    public interface IConnectionManager
    {
        bool AddConnection(string name, string connectionString, out string? error);
        IEnumerable<ServiceBusConnectionViewModel> GetServiceBusConnections();
        void RemoveConnection(string name);
    }
}
