using HogeschoolPXL.Data;
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
        UserManager<IdentityUser> _userManager;
        SignInManager<IdentityUser> _signInManager;
        RoleManager<IdentityRole> _roleManager;
        ApplicationDBContext _context;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, ApplicationDBContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
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
            //if (ModelState.IsValid)
            //{
                var identityUser = await _userManager.FindByEmailAsync(user.Email);
                if (identityUser != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user.Email, user.Password, false, lockoutOnFailure: false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Student");
                    }
                    else
                    {
                        ModelState.AddModelError("", "invalid login attempt");
                    }
                }
            //}
            return View(user);
        }
        //Register
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RegisterAsync(RegisterViewModel user)
        {
            if (ModelState.IsValid)
            {
                var identityUser = new IdentityUser { UserName = user.Email, Email = user.Email };
                var result = await _userManager.CreateAsync(identityUser, user.Password);
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
