using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Serilog.Context;
using System.Diagnostics;
using WebApplication3.AppFilter;
using WebApplication3.Models;
using WebApplication3.Services;

namespace WebApplication3.Controllers
{
    [TimeElapsedFilter]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private UserManager<AppUser> _userManager;
        private IMessage _message;

        public HomeController(ILogger<HomeController> logger,
            UserManager<AppUser> userManager,
            IMessage message)
        {
            _logger = logger;
            _userManager = userManager;
            _message = message;
        }

        //[IEFilter]
        //->[ResourceFilter]: IEFilterAttribute
        public async Task<IActionResult> Index()
        {
            throw new Exception("TEST message");
            //-> [ActionFilter]: TimeElapsedFilter

            //->[ResourceFilter]: IEFilterAttribute
            return View();
            //-> [ActionFilter]: TimeElapsedFilter
        }

        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contact(string name, string email, string message)
        {
            _logger.LogInformation("Попытка отпраки сообщения для пользователя " +
                "{name} на электронный адрес {email}",
                name, email);

            if (_message.SendMessage(email, "From Contact form", message))
            {
                _logger.LogError("При поптки отправить уведомление ({name}, {email}) " +
                    "возникла ошибка", name, email);
            }
            return View();
        }

        public JsonResult setCity(string city)
        {
            try
            {
                CookieOptions options = new CookieOptions();
                options.Expires = DateTime.Now.AddMinutes(1);

                Response.Cookies.Append("city", city, options);

                return Json(city);
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }

        [HttpPost]
        public JsonResult ChangeLanguage(string culture)
        {
            Response.Cookies.Append(
            CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
            new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddDays(7)
            });

            return Json(culture);
        }

        public IActionResult Error(string message)
        {

            return View("Error", message);
        }

    }
}