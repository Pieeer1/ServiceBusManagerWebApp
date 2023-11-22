using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Administration;
using ServiceBusManager.Web.Models;

namespace ServiceBusManager.Web.Services.Interfaces
{
    public interface IServiceBusClientAdminManager
    {
        Task<bool> AddNewSubscription(CreateSubscriptionForm form);
        Task<bool> AddNewTopic(CreateTopicForm form);
        Task<Dictionary<SubscriptionProperties, SubscriptionRuntimeProperties>> GetSubscriptions(string topicName);
        Task<Dictionary<TopicProperties, TopicRuntimeProperties>> GetTopics();
        Task<bool> RemoveSubscription(RemoveSubscriptionForm form);
        Task<bool> RemoveTopic(RemoveTopicForm form);
        Task<(IEnumerable<ServiceBusReceivedMessage>? messages, bool errors)> RetrieveMessages(ReceiveMessageForm form);
        Task<bool> SendServiceBusMessage(string topicName, SendMessageForm sendMessageForm);
        void SetActiveConnection(string key);
    }
}
