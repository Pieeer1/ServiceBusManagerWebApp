namespace ServiceBusManager.Web.Models
{
    public class SortableTableColumn
    {
        public SortableTableColumn(string name, string displayName, bool isSortable)
        {
            Name = name;
            DisplayName = displayName;
            IsSortable = isSortable;
        }

        public string Name { get; set; }
        public string DisplayName { get; set; }
        public bool IsSortable { get; set; }
    }
}
