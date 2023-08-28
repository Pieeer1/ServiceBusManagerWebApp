using System.Timers;

namespace ServiceBusManager.Data.Extensions
{
    public class BlazorTimer
    {
        private Action _timerEndCallback { get; set; }

        private System.Timers.Timer? _timer;
        private double _lifetime;
        private double _lifeTimeTracker = 0.0d;
        private double _frequency;
        public BlazorTimer(Action timerEndCallback, double lifetime, double frequency = 1000d)
        {
            _timerEndCallback = timerEndCallback;
            _lifetime = lifetime;
            _frequency = frequency;
        }

        public void StartTimer() 
        {
            _lifeTimeTracker = 0.0d;
            if (_timer is null)
            {
                _timer = new System.Timers.Timer(_frequency);
                _timer.Elapsed += TimerCounter;
                _timer.Enabled = true;
                _timer.Start();
            }
        }
        private void TimerCounter(object? sender, ElapsedEventArgs e)
        {
            if (sender is null) { return; }
            _lifeTimeTracker++;
            if (_lifeTimeTracker >= _lifetime)
            {
                _timerEndCallback.Invoke();
                _timer?.Stop();
                _timer = null;
            }
        }
    }
}
