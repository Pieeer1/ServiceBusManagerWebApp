namespace ServiceBusManager.Data.Services.Interfaces
{
    public interface IJSLogger
    {
        void Log(string message);
        Task LogAsync(string message);
    }
}
