using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Administration;
using ServiceBusManager.Data.Models;
using ServiceBusManager.Data.Services.Interfaces;

namespace ServiceBusManager.Data.Services
{
    public class ConnectionManager : IConnectionManager
    {
        public Dictionary<string, (ServiceBusClient client, ServiceBusAdministrationClient admin)> _serviceBusClientDictionary = new Dictionary<string, (ServiceBusClient client, ServiceBusAdministrationClient admin)>();

        /// <summary>
        /// Adds a new Administration Client and a Basic Client to the Dictionary with the name.
        /// </summary>
        /// <param name="name">Name of the Connection</param>
        /// <param name="connectionString">Connection String to Attempt a Connection To</param>
        /// <returns>True if the connection was added with the correct name successfully. False if the connection was not added</returns>
        public bool AddConnection(string name, string connectionString, out string? error)
        {
            error = null;
            if (_serviceBusClientDictionary.Keys.Any(x => x.ToLower() == name.ToLower()) || _serviceBusClientDictionary.Keys.Any(x => x.ToLower() == name.ToLower())) 
            {
                error = "Connection Already Exists";
                return false;
            }
            try
            {
                ServiceBusAdministrationClient adminClient = new ServiceBusAdministrationClient(connectionString);
                ServiceBusClient basicClient = new ServiceBusClient(connectionString);

                _serviceBusClientDictionary.Add(name, (basicClient, adminClient));
            }
            catch (Exception ex)
            {
                error = ex.Message;
                return false;
            }
            return true;
        }        
        public IEnumerable<ServiceBusConnectionViewModel> GetServiceBusConnections()
        {
            foreach (var adminPair in _serviceBusClientDictionary)
            {
                yield return new ServiceBusConnectionViewModel(adminPair.Key);
            }
        }
        public (ServiceBusClient client, ServiceBusAdministrationClient admin) GetConnectionByName(string key) => _serviceBusClientDictionary.First(x => x.Key == key).Value;
        public void RemoveConnection(string name)
        {
            _serviceBusClientDictionary.Remove(name);
        }
    }
}
