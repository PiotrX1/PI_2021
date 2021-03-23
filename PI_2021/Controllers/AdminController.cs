using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PI_2021.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PI_2021.Controllers
{
    public class AdminController : Controller
    {

        UserManager<IdentityUser> userManager;

        public AdminController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }


        [Authorize(Policy = "Admin")]
        public IActionResult Index()
        {
            return RedirectToAction("Users");
        }

        [Authorize(Policy = "Admin")]
        public IActionResult Users()
        {
            var users = userManager.Users.ToList();

            return View(users);
        }

        [HttpPost]
        public async Task<IActionResult> Users(NewUserModel NewUser)
        {

            if (ModelState.IsValid)
            {
                var hasher = new PasswordHasher<IdentityUser>();

                await userManager.CreateAsync(new IdentityUser
                {
                    UserName = NewUser.UserName,
                    NormalizedUserName = NewUser.UserName.ToUpper(),
                    Email = NewUser.Email,
                    PasswordHash = hasher.HashPassword(null, NewUser.Password),
                    EmailConfirmed = true
                });
            }
            var users = userManager.Users.ToList();

            return View(users);
        }

    }
}
