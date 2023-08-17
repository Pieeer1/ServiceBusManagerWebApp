using Azure.Messaging.ServiceBus.Administration;
using ServiceBusManager.Data.Services.Interfaces;

namespace ServiceBusManager.Data.Services
{
    public class ServiceBusAdministrator : IServiceBusAdministrator
    {
        private readonly IConnectionManager _connectionManager;
        public ServiceBusAdministrator(IConnectionManager connectionManager)
        {
            _connectionManager = connectionManager;
        }
    }
}
