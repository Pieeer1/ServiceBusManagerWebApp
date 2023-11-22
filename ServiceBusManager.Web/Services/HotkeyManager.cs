using ServiceBusManager.Web.Models.Hotkeys;
using ServiceBusManager.Web.Services.Interfaces;

namespace ServiceBusManager.Web.Services
{
    public class HotkeyManager : IHotkeyManager
    {

        /*
         * TODO - FIX HOLDING DOWN HOTKEY ISSUES
         */

        private HashSet<Hotkey> _activeHotkeys = new HashSet<Hotkey>();

        public void RegisterHotkey(Action action, string actionExplanation, CancellationToken? cts = null, params IPressable[] pressables)
        {
            if (cts is not null)
            {
                cts.Value.Register(() => UnregisterHotkey(pressables));
            }
            if (_activeHotkeys.Any(x => x.IsHotkeyFromPressables(pressables)))
            {
                return;
            }
            _activeHotkeys.Add(new Hotkey(pressables, action, actionExplanation));
        }
        public void RegisterHotkey(Hotkey hotkey, CancellationToken? cts = null)
        {
            if (cts is not null)
            {
                cts.Value.Register(() => UnregisterHotkey(hotkey));
            }
            if (_activeHotkeys.Any(x => x.IsHotkeyFromPressables(hotkey.Pressables)))
            {
                return;
            }
            _activeHotkeys.Add(hotkey);
        }
        public void UnregisterHotkey(params IPressable[] pressables)
        {
            _activeHotkeys.RemoveWhere(x => x.IsHotkeyFromPressables(pressables));
        }
        public void UnregisterHotkey(Hotkey hotkey)
        {
            _activeHotkeys.RemoveWhere(x => x.IsHotkeyFromPressables(hotkey.Pressables));
        }
        public void TriggerHotkey(IPressable[] pressables)
        {
            var keys = pressables.Where(x => x is Key).ToArray();
            var codes = pressables.Where(x => x is Code).ToArray();

            if (_activeHotkeys.Any(x => x.IsHotkeyFromPressables(keys) || x.IsHotkeyFromPressables(codes)))
            {
                _activeHotkeys.First(x => x.IsHotkeyFromPressables(keys) || x.IsHotkeyFromPressables(codes)).Action.Invoke();
            }
        }
        public IEnumerable<Hotkey> GetActiveHotkeys() => _activeHotkeys;
    }
}
