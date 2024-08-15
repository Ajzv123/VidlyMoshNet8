using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VidlyMoshNet8.ViewModel;

namespace VidlyMoshNet8.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        // GET: AccountController
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        // GET: AccountController/Create
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            var IdentityUser = new IdentityUser
            {
                UserName = model.Username,
                Email = model.Email
            };
            var identityResult = await _userManager.CreateAsync(IdentityUser, model.Password);
            if (identityResult.Succeeded)
            {
                var roleIdentityResult = await _userManager.AddToRoleAsync(IdentityUser, "Admin");
                if (roleIdentityResult.Succeeded)
                {
                    await _signInManager.SignInAsync(IdentityUser, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
            }

            return RedirectToAction();
        }

        [HttpGet]
        public ActionResult Login(string ReturnUrl)
        {
            var model = new LoginViewModel
            {
                ReturnUrl = ReturnUrl
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(
                model.Username, model.Password, isPersistent: false, lockoutOnFailure: false);
            if (result.Succeeded)
            {

                if (!string.IsNullOrWhiteSpace(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                {
                    return RedirectToPage(model.ReturnUrl);
                }
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}