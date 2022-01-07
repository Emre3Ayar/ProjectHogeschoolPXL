using HogeschoolPXL.Data;
using HogeschoolPXL.Helpers;
using HogeschoolPXL.Models;
using HogeschoolPXL.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HogeschoolPXL.Controllers
{
    public class AccountController : Controller
    {
        UserManager<CustomIdentityUser> _userManager;
        SignInManager<CustomIdentityUser> _signInManager;
        //RoleManager<IdentityRole> _roleManager;
        ApplicationDBContext _context;

        public AccountController(UserManager<CustomIdentityUser> userManager, SignInManager<CustomIdentityUser> signInManager, ApplicationDBContext context)
        {
            //RoleManager<IdentityRole> roleManager
            _userManager = userManager;
            _signInManager = signInManager;
            //_roleManager = roleManager;
            _context = context;
        }
        //Logout
        public async Task<IActionResult> LogoutAsync()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
        //Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> LoginAsync(LoginViewModel user)
        {
            if (ModelState.IsValid)
            {
                var identityUser = await _userManager.FindByEmailAsync(user.Email);
                if (identityUser != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, false, lockoutOnFailure: false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("", "invalid login attempt");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "invalid login attempt");
                }
            }
            return View(user);
        }
        //Register
        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.Roles = new SelectList(RoleHelper.Roles);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterAsync(RegisterViewModel user)
        {
            if (ModelState.IsValid)
            {
                var customIdentityUser = new CustomIdentityUser { UserName = user.Email, Email = user.Email};
                customIdentityUser.RoleName = user.RoleName;
                var result = await _userManager.CreateAsync(customIdentityUser, user.Password);
                if (result.Succeeded)
                {
                    return View("Login");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(user);
                }
            }
            return View(user);
        }
    }
}
