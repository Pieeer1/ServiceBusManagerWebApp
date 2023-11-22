using ServiceBusManager.Web.Models.Hotkeys;

namespace ServiceBusManager.Web.Services.Interfaces
{
    public interface IHotkeyManager
    {
        IEnumerable<Hotkey> GetActiveHotkeys();
        void RegisterHotkey(Action action, string actionExplanation, CancellationToken? cts = null, params IPressable[] pressables);
        void RegisterHotkey(Hotkey hotkey, CancellationToken? cts = null);
        void TriggerHotkey(IPressable[] pressables);
        void UnregisterHotkey(params IPressable[] pressables);
        void UnregisterHotkey(Hotkey hotkey);
    }
}
