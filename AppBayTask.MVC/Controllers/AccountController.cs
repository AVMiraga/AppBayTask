using AppBayTask.Business.Services.Interfaces;
using AppBayTask.Business.ViewModels;
using AppBayTask.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AppBayTask.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _service;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(IAccountService service, SignInManager<AppUser> signInManager)
        {
            _service = service;
            _signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVm registerVm)
        {
            if (!ModelState.IsValid)
            {
                return View(registerVm);
            }

            RegisterResult registerResult = await _service.RegisterAsync(registerVm);

            if (!registerResult.Result.Succeeded)
            {
                foreach (var error in registerResult.Result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View(registerVm);
            }

            await _signInManager.SignInAsync(registerResult.User, false);

            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVm loginVm)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVm);
            }

            AppUser user = await _service.ValidateUserCredentialsAsync(loginVm);

            if (user == null)
            {
                ModelState.AddModelError("", "Username Or Password is wrong");
                return View(loginVm);
            }

            var res = await _signInManager.PasswordSignInAsync(user, loginVm.Password, false, false);

            if (!res.Succeeded)
            {
                ModelState.AddModelError("", "Username Or Password is wrong");
                return View(loginVm);
            }

            if (res.IsLockedOut)
            {
                ModelState.AddModelError("", "Account is locked");
                return View(loginVm);
            }

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> CreateRole()
        {
            await _service.CreateRoleAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}