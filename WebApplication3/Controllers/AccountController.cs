using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<AppUser> _userManager;
        private SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            Login login = new Login();
            login.ReturnUrl = returnUrl;

            return View(login);
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login login)
        {
            AppUser user = await _userManager.FindByEmailAsync(login.Email);

            if(user!=null)
            {
                await _signInManager.SignOutAsync();

                var result = await _signInManager
                    .PasswordSignInAsync(user, login.Password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(login);
        }
    }
}
