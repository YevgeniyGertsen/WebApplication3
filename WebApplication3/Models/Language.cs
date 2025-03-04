using Twilio.Rest.Insights.V1;

namespace WebApplication3.Models
{
    public partial class Language
    {
        public Language()
        {
            StringResources = new HashSet<StringResources>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Culture { get; set; }

        public virtual ICollection<StringResources> StringResources { get; set; }
    }
}
