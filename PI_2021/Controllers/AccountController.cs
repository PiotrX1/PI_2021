using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PI_2021.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PI_2021.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager) 
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [Authorize]
        public IActionResult Index()
        {
            userManager.GetUserAsync(User);
            return View();
        }


        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()
        {
            UserLoginModel model = new UserLoginModel();
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginModel model)
        {
            if(ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(model.Username);
                if(await userManager.CheckPasswordAsync(user, model.Password) == false)
                {
                    ModelState.AddModelError("message", "Niepoprane dane logowania");
                    return View(model);
                }

                var result = await signInManager.PasswordSignInAsync(user, model.Password, true, false);

                if(result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else if(result.IsLockedOut)
                {
                    ModelState.AddModelError("message", "Konto zablokowane");
                    return View(model);
                }
                else
                {
                    ModelState.AddModelError("message", "Logowanie niepoprawne");
                    return View(model);
                }

            }


            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return Redirect("~/");
        }


        public IActionResult Forbidden()
        {
            return View();
        }

    }

}
