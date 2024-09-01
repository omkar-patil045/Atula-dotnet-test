using AtulaDotNetTest.Models.Entities;
using AtulaDotNetTest.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AtulaDotNetTest.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            // Attempt to sign in the user
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: true);

            if (result.Succeeded)
            {
                // Redirect to Products page upon successful login
                return RedirectToAction("Index", "Products");
            }
            else if (result.IsLockedOut)
            {
                // Handle account lockout
                ModelState.AddModelError(string.Empty, "Your account has been locked out.");
            }
            else
            {
                // Handle invalid login attempt
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }

            // Return to the login view with the current model
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }

}
