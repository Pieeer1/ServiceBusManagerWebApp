﻿using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Administration;
using ServiceBusManager.Data.Models;
using ServiceBusManager.Data.Services.Interfaces;

namespace ServiceBusManager.Data.Services
{
    public class ServiceBusClientAdminManager : IServiceBusClientAdminManager
    {
        private readonly IConnectionManager _connectionManager;

        private (ServiceBusClient client, ServiceBusAdministrationClient admin) _activeConnection;
        private KeyValuePair<string, ServiceBusSender> _topicSender;
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
        public async Task<bool> SendServiceBusMessage(string topicName, string messageBody, Dictionary<string, string> messageProperties)
        {
            try
            {
                if (_topicSender.Key != topicName)
                {
                    _topicSender = new KeyValuePair<string, ServiceBusSender>(topicName, _activeConnection.client.CreateSender(topicName));
                }
                var message = new ServiceBusMessage()
                {
                    Body = new BinaryData(messageBody),
                    MessageId = Guid.NewGuid().ToString(),
                };
                foreach (var item in messageProperties)
                {
                    message.ApplicationProperties.Add(item.Key, item.Value); //TODO - VALIDATE PROPERTIES ARE SENDING.... LOOKS LIKE THEY MIGHT NOT BE
                }
                
                await _topicSender.Value.SendMessageAsync(message);
            }
            catch
            {
                return false;
            }
            return true;
        }
    }
}
