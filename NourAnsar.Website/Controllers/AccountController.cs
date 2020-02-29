using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using NourAnsar.Website.Extensions;
using NourAnsar.Website.Models;
using NourAnsar.Website.Resources;
using NourAnsar.Website.ViewModels;


namespace NourAnsar.Website.Controllers
{

    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly ILogger _logger;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ILogger<AccountController> logger,
            IStringLocalizer<SharedResources> localizer)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _localizer = localizer;
        }

        public IActionResult Index(string message= "",string email="")
        {
            TempData["Message"] = message;
            TempData["Email"] = email;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM model)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    //HttpContext.Session.Set("");
                    return RedirectToAction("Index", "Dashboard");
                }
                else if (result.IsLockedOut)
                {
                    message  = _localizer["MSG_AccountLocked"].Value;                    
                }
                else
                {
                    message = _localizer["MSG_IncorrectLogin"].Value;
                }
            }
            else
            {
                message = ModelBase.GetValidationErrors(ModelState);
            }
            return RedirectToAction("Index", "Account", new { message = message, email = model.Email });
        }
    }
}