using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Administration;
using ServiceBusManager.Data.Models;
using ServiceBusManager.Data.Services.Interfaces;

namespace ServiceBusManager.Data.Services
{
    public class ConnectionManager : IConnectionManager
    {
        public Dictionary<string, ServiceBusAdministrationClient> _serviceBusAdministrationDictionary = new Dictionary<string, ServiceBusAdministrationClient>();
        public Dictionary<string, ServiceBusClient> _serviceBusClientDictionary = new Dictionary<string, ServiceBusClient>();

        /// <summary>
        /// Adds a new Administration Client and a Basic Client to the Dictionary with the name.
        /// </summary>
        /// <param name="name">Name of the Connection</param>
        /// <param name="connectionString">Connection String to Attempt a Connection To</param>
        /// <returns>True if the connection was added with the correct name successfully. False if the connection was not added</returns>
        public bool AddConnection(string name, string connectionString, out string? error)
        {
            error = null;
            if (_serviceBusAdministrationDictionary.Keys.Any(x => x.ToLower() == name.ToLower()) || _serviceBusClientDictionary.Keys.Any(x => x.ToLower() == name.ToLower())) 
            {
                error = "Connection Already Exists";
                return false;
            }
            try
            {
                ServiceBusAdministrationClient adminClient = new ServiceBusAdministrationClient(connectionString);
                ServiceBusClient basicClient = new ServiceBusClient(connectionString);

                _serviceBusAdministrationDictionary.Add(name, adminClient);
                _serviceBusClientDictionary.Add(name, basicClient);
            }
            catch (Exception ex)
            {
                error = ex.Message;
            }
            return true;
        }
        public IEnumerable<ServiceBusConnectionViewModel> GetServiceBusConnections()
        {
            foreach (var adminPair in _serviceBusAdministrationDictionary)
            {
                yield return new ServiceBusConnectionViewModel(adminPair.Key);
            }
        }
        public void RemoveConnection(string name)
        {
            _serviceBusAdministrationDictionary.Remove(name);
            _serviceBusClientDictionary.Remove(name);
        }
    }
}
