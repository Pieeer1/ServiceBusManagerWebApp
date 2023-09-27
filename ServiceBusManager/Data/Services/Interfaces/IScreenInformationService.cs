using ServiceBusManager.Data.Models.JS;

namespace ServiceBusManager.Data.Services.Interfaces
{
    public interface IScreenInformationService
    {
        event EventHandler? WindowResized;

        Task<WindowDimensions> GetScreenSize();
        Task Init();
    }
}
