namespace ServiceBusManager.Web.Services.Interfaces
{
    public interface IJSLogger
    {
        void Log(string message);
        Task LogAsync(string message);
    }
}
