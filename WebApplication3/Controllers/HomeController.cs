using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Serilog.Context;
using System.Diagnostics;
using WebApplication3.Models;
using WebApplication3.Services;

namespace WebApplication3.Controllers
{
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


        public async Task<IActionResult> Index()
        {
          
            _logger.LogTrace("Logging Trace Message");
            _logger.LogDebug("Logging Debug Message");
            _logger.LogInformation("Logging Information Message");
            _logger.LogWarning("Logging Warning Message");
            _logger.LogError("Logging Error Message");
            _logger.LogCritical("Logging Critical Message");


            //AppUser user = new AppUser();
            //user.UserName = "admin";
            //user.Email = "gersen.e.a@gmail.com";
            //var result = await _userManager.CreateAsync(user, "Gg110188@");

            //if (result.Succeeded)
            //{

            //}
            return View();
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
        public IActionResult ChangeLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
            CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
            new CookieOptions
            {
                Expires = DateTimeOffset.UtcNow.AddDays(7)
            }
            );

            return LocalRedirect(returnUrl);
        }

    }
}