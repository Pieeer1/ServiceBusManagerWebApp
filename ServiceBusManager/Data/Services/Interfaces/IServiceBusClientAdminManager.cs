using Azure.Messaging.ServiceBus.Administration;

namespace ServiceBusManager.Data.Services.Interfaces
{
    public interface IServiceBusClientAdminManager
    {
        Task<IEnumerable<TopicProperties>> GetTopics();
        void SetActiveConnection(string key);
    }
}
