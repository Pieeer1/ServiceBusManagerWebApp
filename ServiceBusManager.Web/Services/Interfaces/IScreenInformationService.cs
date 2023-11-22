using ServiceBusManager.Web.Models.JS;

namespace ServiceBusManager.Web.Services.Interfaces
{
    public interface IScreenInformationService
    {
        event EventHandler? WindowResized;

        Task<WindowDimensions> GetScreenSize();
        Task Init();
    }
}
