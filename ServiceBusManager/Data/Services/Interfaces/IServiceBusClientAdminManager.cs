﻿using Azure.Messaging.ServiceBus.Administration;
using ServiceBusManager.Data.Models;

namespace ServiceBusManager.Data.Services.Interfaces
{
    public interface IServiceBusClientAdminManager
    {
        Task<Dictionary<SubscriptionProperties, SubscriptionRuntimeProperties>> GetSubscriptions(string topicName);
        Task<Dictionary<TopicProperties, TopicRuntimeProperties>> GetTopics();
        Task<bool> SendServiceBusMessage(string topicName, string messageBody, Dictionary<string, string> messageProperties);
        void SetActiveConnection(string key);
    }
}
