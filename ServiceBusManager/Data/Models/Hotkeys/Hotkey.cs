namespace ServiceBusManager.Data.Models.Hotkeys
{
    public class Hotkey
    {
        public Hotkey(IEnumerable<IPressable> pressables, Action action)
        {
            Pressables = pressables;
            Action = action;
        }

        public IEnumerable<IPressable> Pressables { get; private set; }
        public Action Action { get; private set; }


        public bool IsHotkeyFromPressables(IEnumerable<IPressable> pressables)
        {
            return Pressables.SequenceEqual(pressables);
        }

    }
}
