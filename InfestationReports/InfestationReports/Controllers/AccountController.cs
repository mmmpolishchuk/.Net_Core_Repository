using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfestationReports.Infrastructure.Configuration;
using InfestationReports.Infrastructure.Services.Implementations;
using InfestationReports.Infrastructure.Services.Interfaces;
using InfestationReports.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace InfestationReports.Controllers
{
    public class AccountController : Controller
    {
        private SignInManager<IdentityUser> SignInManager { get; }
        private UserManager<IdentityUser> UserManager { get; }
        private IMessageService MessageService { get; }

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,
            IMessageService messageService)
        {
            SignInManager = signInManager;
            UserManager = userManager;
            MessageService = messageService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(AccountRegisterViewModel account)
        {
            var user = new IdentityUser() {Email = account.Email, UserName = account.Email};
            var createTask = UserManager.CreateAsync(user, account.Password);

            if (createTask.Result.Succeeded)
            {
                SignInManager.SignInAsync(user, false);

                MessageService.SendMessage("Sms-o4ka", "",
                    SenderType.Sms);

                return RedirectToAction("Index", "News");
            }

            foreach (var error in createTask.Result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }

            ViewData["errors"] = createTask.Result.Errors;
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(AccountLoginViewModel accountLoginViewModel, [FromQuery] string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var sighInTask =
                    SignInManager.PasswordSignInAsync(accountLoginViewModel.Email, accountLoginViewModel.Password,
                        accountLoginViewModel.RememberMe,
                        false);

                if (sighInTask.Result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }

                    return RedirectToAction("Index", "Human");
                }

                ModelState.AddModelError("", "Incorrect password or email.");
            }

            return View();
        }

        [HttpPost]
        public IActionResult Logout()
        {
            SignInManager.SignOutAsync();

            return RedirectToAction("Index", "Human");
        }
    }
}