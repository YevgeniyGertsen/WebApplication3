namespace WebApplication3.Models
{
    public class TeamViewModel
    {
        public string ImagePath { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public string Description { get; set; }
        public List<TeamLink> TeamLinks { get; set; }
    }
    public class TeamLink
    {
        public string URL { get; set; }
        public string LinkType { get; set; }
    }
}