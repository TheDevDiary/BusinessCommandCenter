namespace webapi.Models
{
    public class Dashboard
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        // List of widgets on the dashboard
        public List<Widget> Widgets { get; set; }
        public bool IsDefault { get; set; }
        public string LayoutConfiguration { get; set; }
        
    }

    public class Widget
    {
        public int Id {get; set; }
        public string Name { get; set; }
        public string Type { get; set; } // Type of widget (list, notification, etc)
        public string Configuration { get; set; } // Configuration data for the widget.        
    }
}
