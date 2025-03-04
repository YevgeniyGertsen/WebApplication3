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

        public IEnumerable<Language> GetLanguages()
        {
            return _context.Language.ToList();
        }

        public Language GetLanguageByCulture(string culture)
        {
            return _context.Language.FirstOrDefault(x =>
            x.Culture.Trim().ToLower() == culture.Trim().ToLower());
        }
    }
}
