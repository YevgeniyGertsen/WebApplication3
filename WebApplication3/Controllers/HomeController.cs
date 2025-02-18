using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private UserManager<AppUser> _userManager;
        public HomeController(ILogger<HomeController> logger, 
            UserManager<AppUser> userManager)
        {
            _logger = logger;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
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
        
       
        public IActionResult AddMessage(string name, string email, string message)
        {
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
    }
}