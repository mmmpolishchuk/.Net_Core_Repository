using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfestationReports.Infrastructure.Services.Implementations;
using InfestationReports.Infrastructure.Services.Interfaces;
using InfestationReports.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace InfestationReports.Controllers
{
    public class AccountController : Controller
    {
        public SignInManager<IdentityUser> SignInManager { get; }
        public UserManager<IdentityUser> UserManager { get; }
        public IMessageService<Email> EmailSender { get; }
        public IMessageService<Sms> SmsSender { get; }

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,
            IMessageService<Sms> smsSender, IMessageService<Email> emailSender)
        {
            SignInManager = signInManager;
            UserManager = userManager;
            EmailSender = emailSender;
            SmsSender = smsSender;
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
                if (account.SendEmail)
                {
                    EmailSender.SendMessage();
                }
                else if (account.SendSms)
                {
                    SmsSender.SendMessage();
                }

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