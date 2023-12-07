namespace Assignment1.Models
{
    public class NavbarButton
    {
        public int Id { get; set; }
        public string ButtonName { get; set; }

        public string? Url { get; set; }
        public bool IsSelected { get; set; }

        public int? Order { get; set; }
    }
}
