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

        public async Task<Dictionary<TopicProperties, TopicRuntimeProperties>> GetTopics()
        { 
            List<TopicProperties> topics = new List<TopicProperties>();
            List<TopicRuntimeProperties> topicRuntimes = new List<TopicRuntimeProperties>();
            await foreach (var item in _activeConnection.admin.GetTopicsAsync().AsPages())
            {
                topics.AddRange(item.Values);
            }
            await foreach (var item in _activeConnection.admin.GetTopicsRuntimePropertiesAsync().AsPages())
            {
                topicRuntimes.AddRange(item.Values);
            }
            Dictionary<TopicProperties, TopicRuntimeProperties> topicRunDict = new Dictionary<TopicProperties, TopicRuntimeProperties>();
            for (int i = 0; i < topics.Count; i++)
            {
                topicRunDict.Add(topics.ElementAt(i), topicRuntimes.ElementAt(i));
            }
            return topicRunDict;
        }
        public async Task<Dictionary<SubscriptionProperties, SubscriptionRuntimeProperties>> GetSubscriptions(string topicName)
        {
            List<SubscriptionProperties> subscriptions = new List<SubscriptionProperties>();
            List<SubscriptionRuntimeProperties> subscriptionRuntimes = new List<SubscriptionRuntimeProperties>();
            await foreach (var item in _activeConnection.admin.GetSubscriptionsAsync(topicName).AsPages())
            {
                subscriptions.AddRange(item.Values); 
            }            
            await foreach (var item in _activeConnection.admin.GetSubscriptionsRuntimePropertiesAsync(topicName).AsPages())
            {
                subscriptionRuntimes.AddRange(item.Values); 
            }
            Dictionary<SubscriptionProperties, SubscriptionRuntimeProperties> subscriptionRunDict = new Dictionary<SubscriptionProperties, SubscriptionRuntimeProperties>();
            for (int i = 0; i < subscriptions.Count; i++)
            {
                subscriptionRunDict.Add(subscriptions.ElementAt(i), subscriptionRuntimes.ElementAt(i));
            }

            return subscriptionRunDict;
        }
    }
}
