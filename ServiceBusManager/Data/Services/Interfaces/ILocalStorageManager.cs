namespace ServiceBusManager.Data.Services.Interfaces
{
    public interface ILocalStorageManager
    {
        Task AddConnectionToLocalStorage(string name, string connectionString);
        Task<Dictionary<string, string>> GetConnections();
        Task RemoveConnectionFromLocalStorage(string name);
    }
}
