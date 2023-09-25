using Azure.Messaging.ServiceBus;
using Azure.Messaging.ServiceBus.Administration;
using ServiceBusManager.Data.Models;
using ServiceBusManager.Data.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace ServiceBusManager.Data.Services
{
    public class ConnectionManager : IConnectionManager
    {
        public Dictionary<string, (ServiceBusClient client, ServiceBusAdministrationClient admin)> _serviceBusClientDictionary = new Dictionary<string, (ServiceBusClient client, ServiceBusAdministrationClient admin)>();

        public bool AddConnection(AddConnectionForm addConnectionForm, out string? error)
        {
            error = null;
            var context = new ValidationContext(addConnectionForm);
            if (!Validator.TryValidateObject(addConnectionForm, context, null, true))
            {
                return false;
            }
            if (_serviceBusClientDictionary.Keys.Any(x => x.ToLower() == addConnectionForm.Name.ToLower()) || _serviceBusClientDictionary.Keys.Any(x => x.ToLower() == addConnectionForm.Name.ToLower()))
            {
                error = "Connection Already Exists";
                return false;
            }
            try
            {
                ServiceBusAdministrationClient adminClient = new ServiceBusAdministrationClient(addConnectionForm.ConnectionString);
                ServiceBusClient basicClient = new ServiceBusClient(addConnectionForm.ConnectionString);

                _serviceBusClientDictionary.Add(addConnectionForm.Name, (basicClient, adminClient));
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
                yield return new ServiceBusConnectionViewModel(adminPair.Key, adminPair.Value.client.TransportType, adminPair.Value.client.FullyQualifiedNamespace, adminPair.Value.client.Identifier);
            }
        }
        public (ServiceBusClient client, ServiceBusAdministrationClient admin) GetConnectionByName(string key) => _serviceBusClientDictionary.First(x => x.Key == key).Value;
        public void RemoveConnection(string name)
        {
            _serviceBusClientDictionary.Remove(name);
        }
    }
}
