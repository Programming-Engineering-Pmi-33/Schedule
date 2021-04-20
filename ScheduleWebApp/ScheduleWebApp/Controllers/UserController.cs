using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ScheduleWebApp.BLL;
using ScheduleWebApp.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ScheduleWebApp.Controllers
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        private UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }
       
        public ActionResult Login()
        {
            return View(new LoginModel());
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel user)
        {
            if (ModelState.IsValid)
            {
                var salt = _userService.GetUserSalt(user.Surname);

                if (string.IsNullOrEmpty(salt))
                {
                    ModelState.AddModelError(string.Empty, "No such surname in database");

                    return View(user);
                }

                var userId = _userService.GetUserId(user, salt);

                if (userId > 0)
                {
                    ClaimsPrincipal principal = _userService.GetPrincipal(userId);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                    return RedirectToAction("Show", "Teacher", new { area = "" });
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Wrong password");

                    return View(user);
                }
            }
            else
            {
                return View(user);
            }
        }

        [HttpPost]
        public async void LogOut()
        {
            await HttpContext.SignOutAsync();
        }
    }
}