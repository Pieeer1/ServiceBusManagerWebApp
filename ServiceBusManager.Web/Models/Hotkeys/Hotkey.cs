namespace ServiceBusManager.Web.Models.Hotkeys
{
    public class Hotkey
    {
        public Hotkey(IEnumerable<IPressable> pressables, Action action, string actionExplanation)
        {
            Pressables = pressables;
            Action = action;
            ActionExplanation = actionExplanation;
        }

        public IEnumerable<IPressable> Pressables { get; private set; }
        public Action Action { get; private set; }
        public string ActionExplanation { get; private set; }

        public bool IsHotkeyFromPressables(IEnumerable<IPressable> pressables)
        {
            return Pressables.SequenceEqual(pressables);
        }

    }
}
