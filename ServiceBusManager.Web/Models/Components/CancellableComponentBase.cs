﻿using Microsoft.AspNetCore.Components;

namespace ServiceBusManager.Web.Models.Components
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
