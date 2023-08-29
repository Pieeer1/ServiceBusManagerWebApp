using Azure.Messaging.ServiceBus.Administration;

namespace ServiceBusManager.Data.Services.Interfaces
{
    public interface IServiceBusClientAdminManager
    {
        Task<Dictionary<SubscriptionProperties, SubscriptionRuntimeProperties>> GetSubscriptions(string topicName);
        Task<Dictionary<TopicProperties, TopicRuntimeProperties>> GetTopics();
        void SetActiveConnection(string key);
    }
}
