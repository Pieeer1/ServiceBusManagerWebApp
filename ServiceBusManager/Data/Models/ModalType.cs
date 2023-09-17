namespace ServiceBusManager.Data.Models
{
    public enum ModalType
    {
        Default,
        Large,
        Fullscreen
    }
    public static class ModalTypeExtensions
    {
        public static string GetCssFromModalType(this ModalType modalType) =>
            modalType switch
            {
                ModalType.Fullscreen => "modal-fullscreen",
                ModalType.Large => "modal-lg",
                ModalType.Default => string.Empty,
                _ => string.Empty
            };
    }
}
