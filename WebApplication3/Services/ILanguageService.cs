using WebApplication3.Models;

namespace WebApplication3.Services
{
    public interface ILanguageService
    {
        public IEnumerable<Language> GetLanguages();
        public Language GetLanguageByCulture(string culture);
    }
}
