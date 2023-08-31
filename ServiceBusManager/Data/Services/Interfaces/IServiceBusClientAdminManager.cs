using Azure.Messaging.ServiceBus.Administration;
using ServiceBusManager.Data.Models;

namespace ServiceBusManager.Data.Services.Interfaces
{
    public interface IServiceBusClientAdminManager
    {
        Task<bool> AddNewTopic(CreateTopicForm form);
        Task<Dictionary<SubscriptionProperties, SubscriptionRuntimeProperties>> GetSubscriptions(string topicName);
        Task<Dictionary<TopicProperties, TopicRuntimeProperties>> GetTopics();
        Task<bool> SendServiceBusMessage(string topicName, SendMessageForm sendMessageForm);
        void SetActiveConnection(string key);
    }
}
