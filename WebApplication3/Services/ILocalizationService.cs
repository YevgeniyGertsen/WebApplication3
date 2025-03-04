using WebApplication3.Models;

namespace WebApplication3.Services
{
    public interface ILocalizationService
    {
        public StringResources GetStringResources(string recourceKey, int languageId);
    }
}
