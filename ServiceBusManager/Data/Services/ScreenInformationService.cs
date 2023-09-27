using Microsoft.JSInterop;
using ServiceBusManager.Data.Models.JS;
using ServiceBusManager.Data.Services.Interfaces;

namespace ServiceBusManager.Data.Services
{
    public class ScreenInformationService : IScreenInformationService
    {
        private readonly IJSRuntime _jsRuntime;
        private IJSObjectReference? _importedGetDimensionsRuntimeReference;
        public event EventHandler? WindowResized;
        public ScreenInformationService(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task<WindowDimensions> GetScreenSize()
        {
            if (_importedGetDimensionsRuntimeReference is null)
            {
                _importedGetDimensionsRuntimeReference = await _jsRuntime.InvokeAsync<IJSObjectReference>("import", "./Scripts/getDimensions.js");
            }
            return await _importedGetDimensionsRuntimeReference.InvokeAsync<WindowDimensions>("getDimensions");
        }
        public async Task Init()
        {
            var browserResizedReference = await _jsRuntime.InvokeAsync<IJSObjectReference>("import", "./Scripts/resizeListener.js");
            await browserResizedReference.InvokeAsync<string>("resizeListener", DotNetObjectReference.Create(this));
        }
        [JSInvokable]
        public void BrowserResized()
        {
            WindowResized?.Invoke(this, EventArgs.Empty);
        }
    }
}
