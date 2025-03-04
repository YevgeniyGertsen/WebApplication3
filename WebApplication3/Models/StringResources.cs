namespace WebApplication3.Models
{
    public class StringResources
    {
        public int Id { get; set; }
        public int LanguageId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public virtual Language Language { get; set; }
    }
}
