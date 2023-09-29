using ServiceBusManager.Data.Models;

namespace ServiceBusManager.Data.Services.Interfaces
{
    public interface ILocalStorageManager
    {
        Task AddConnectionToLocalStorage(AddConnectionForm addConnectionForm);
        Task<Dictionary<string, string>> GetConnections();
        Task<LocalSettings?> GetLocalSettings();
        Task RemoveConnectionFromLocalStorage(string name);
        Task UpdateLocalSettings(LocalSettings localSettings);
    }
}
