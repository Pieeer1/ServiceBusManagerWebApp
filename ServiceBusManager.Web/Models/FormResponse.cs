namespace ServiceBusManager.Web.Models
{
    /// <summary>
    /// This class sole purpose is to act as the middleman between the InputText and the form properties as reference
    /// https://stackoverflow.com/questions/59340621/blazor-bind-data-to-collection
    /// TODO - potentially refactor to take all value types as a wrapper?
    /// </summary>
    public class FormResponse
    {
        public string Value { get; set; } = string.Empty;
    }
}
