namespace ServiceBusManager.Web.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class FriendlyNameAttribute : Attribute
    {
        public string Name { get; set; }

        public FriendlyNameAttribute(string name)
        {
            Name = name;
        }
    }
}
