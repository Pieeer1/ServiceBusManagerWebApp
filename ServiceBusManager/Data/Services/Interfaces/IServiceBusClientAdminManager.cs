using Azure.Messaging.ServiceBus.Administration;

namespace ServiceBusManager.Data.Services.Interfaces
{
    public interface IServiceBusClientAdminManager
    {
        Task<IEnumerable<SubscriptionProperties>> GetSubscriptions(string topicName);
        Task<IEnumerable<TopicProperties>> GetTopics();
        void SetActiveConnection(string key);
    }
}
