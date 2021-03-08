using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HeyCurator_MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using HeyCurator_MVC.Areas.Identity.Pages.Account;
using Microsoft.AspNetCore.Http;

namespace HeyCurator_MVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<HomeController> _logger;
        private SignInManager<IdentityUser> _signInManager;
        private IHttpContextAccessor _httpContext;
        public HomeController(ILogger<HomeController> logger, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IHttpContextAccessor httpContext)
        {
            _userManager = userManager;
            _logger = logger;
            _signInManager = signInManager;
            _httpContext = httpContext;
        }
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("/")]
        public IActionResult EmployeeLogin()
        {
            if(_signInManager.IsSignedIn(User))
            {
               return RedirectToAction("Home");
            }


            return View();
        }

        public async Task<IActionResult> LoginEmployee(LoginModel login)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(login.Input.Email);
                var username = await _userManager.GetUserNameAsync(user);
                var result = await _signInManager.PasswordSignInAsync(username, login.Input.Password, login.Input.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");

                    HttpContext.Session.SetString("username", username);
                    return RedirectToAction("Home", "Index");
                }
                if (result.IsLockedOut)
                {
                    _logger.LogWarning("User account locked out.");
                    return RedirectToPage("./Lockout");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View("EmployeeLogin");
                }
            }

            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Search()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        public IActionResult Home()
        {


            return View();
        }


    }
}
