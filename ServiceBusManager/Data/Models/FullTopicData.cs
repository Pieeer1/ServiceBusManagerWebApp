using Azure.Messaging.ServiceBus.Administration;

namespace ServiceBusManager.Data.Models
{
    public class FullTopicData
    {
        public FullTopicData(TopicProperties topicProperties) 
        {
            TopicProperties = topicProperties;
        }

        public TopicProperties TopicProperties { get; private set; }
        public IEnumerable<SubscriptionProperties>? SubscriptionProperties { get; set; }
    }
}
