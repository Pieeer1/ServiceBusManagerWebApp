using Azure.Messaging.ServiceBus.Administration;

namespace ServiceBusManager.Data.Models
{
    public class FullTopicData
    {
        public FullTopicData(TopicProperties topicProperties, TopicRuntimeProperties topicRuntimeProperties) 
        {
            TopicProperties = topicProperties;
            TopicRuntimeProperties = topicRuntimeProperties;
        }

        public TopicProperties TopicProperties { get; private set; }
        public TopicRuntimeProperties TopicRuntimeProperties { get; private set; }
        public IEnumerable<SubscriptionProperties>? SubscriptionProperties { get; set; }
        public IEnumerable<SubscriptionRuntimeProperties>? SubscriptionRuntimeProperties { get; set; }
    }
}
