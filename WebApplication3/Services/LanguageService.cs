using WebApplication3.Models;

namespace WebApplication3.Services
{
    public class LanguageService : ILanguageService
    {
        private readonly AppIdentityDbContext _context;
        public LanguageService(AppIdentityDbContext context)
        {
            _context = context;
        }

        public Language GetLanguageByCulture(string culture)
        {
            return _context.Language.FirstOrDefault(f => f.Culture.Equals(culture));
        }

        public IEnumerable<Language> GetLanguages()
        {
            return _context.Language;
        }
    }
}
