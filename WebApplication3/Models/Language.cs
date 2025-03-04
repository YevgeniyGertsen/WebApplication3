namespace WebApplication3.Models
{
    public class Language
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Culture { get; set; }

        public virtual ICollection<StringResources> StringResources { get; set;}
    }
}
