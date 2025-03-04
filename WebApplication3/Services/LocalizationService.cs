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

        public StringResources GetStringResource(string resourceKey, int languageId)
        {
            return _context.StringResources.FirstOrDefault(x =>
            x.Name.Trim().ToLower() == resourceKey.Trim().ToLower()
            && x.LanguageId == languageId);
        }
    }
}
