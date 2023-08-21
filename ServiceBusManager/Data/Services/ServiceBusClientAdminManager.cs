using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Administration;
using ServiceBusManager.Data.Services.Interfaces;

namespace ServiceBusManager.Data.Services
{
    public class ServiceBusClientAdminManager : IServiceBusClientAdminManager
    {
        private readonly IConnectionManager _connectionManager;
        private (ServiceBusClient client, ServiceBusAdministrationClient admin) _activeConnection;
        public ServiceBusClientAdminManager(IConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
        }

        public void SetActiveConnection(string key)
        {
            _activeConnection = _connectionManager.GetConnectionByName(key);
        }

        public async Task<IEnumerable<TopicProperties>> GetTopics()
        { 
            List<TopicProperties> topics = new List<TopicProperties>();
            await foreach (var item in _activeConnection.admin.GetTopicsAsync().AsPages())
            {
                topics.AddRange(item.Values);
            }
            return topics;
        }
    }
}
