using ServiceBusManager.Data.Models.Hotkeys;

namespace ServiceBusManager.Data.Services.Interfaces
{
    public interface IHotkeyManager
    {
        void RegisterHotkey(Action action, CancellationToken? cts = null, params IPressable[] pressables);
        void RegisterHotkey(Hotkey hotkey, CancellationToken? cts = null);
        void TriggerHotkey(IPressable[] pressables);
        void UnregisterHotkey(params IPressable[] pressables);
        void UnregisterHotkey(Hotkey hotkey);
    }
}
