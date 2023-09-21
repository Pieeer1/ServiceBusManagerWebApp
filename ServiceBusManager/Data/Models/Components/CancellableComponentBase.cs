using Microsoft.AspNetCore.Components;

namespace ServiceBusManager.Data.Models.Components
{
    public abstract class CancellableComponentBase : ComponentBase, IDisposable
    {
        private CancellationTokenSource? _cancellationTokenSource;
        protected CancellationToken ComponentDetached => (_cancellationTokenSource ??= new()).Token;

        public virtual void Dispose()
        {
            if (_cancellationTokenSource != null)
            {
                _cancellationTokenSource.Cancel();
                _cancellationTokenSource.Dispose();
                _cancellationTokenSource = null;
            }
        }
    }
}
