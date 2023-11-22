using Microsoft.JSInterop;
using ServiceBusManager.Web.Services.Interfaces;

namespace ServiceBusManager.Web.Services
{
    public class JSLogger : IJSLogger
    {
        private readonly IJSRuntime _jsRuntime;

        public JSLogger(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }
        public void Log(string message)
        {
            Task.Run(async () => await LogAsync(message));
        }
        public async Task LogAsync(string message)
        {
            await _jsRuntime.InvokeAsync<string>("console.log", message);
        }
    }
}
