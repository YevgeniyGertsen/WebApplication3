using WebApplication3.Models;

namespace WebApplication3.Services
{
    public class LocalizationService : ILocalizationService
    {
        private readonly AppIdentityDbContext _context;
        public LocalizationService(AppIdentityDbContext context)
        {
            _context = context;
        }

        public StringResources GetStringResources(string recourceKey, int languageId)
        {
            return _context.StringResources.FirstOrDefault(f => f.Name.Equals(recourceKey) &&
            f.LanguageId.Equals(languageId));
        }
    }
}
