using WebApplication3.Models;

namespace WebApplication3.Services
{
    public interface ILocalizationService
    {
        StringResources GetStringResource(string resourceKey, int languageId);
    }

}
