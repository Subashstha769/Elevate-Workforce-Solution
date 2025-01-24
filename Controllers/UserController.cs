using System.Runtime.Serialization;
using Microsoft.AspNetCore.Mvc;
using WebLab2024.Interfaces;
using WebLab2024.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace WebLab2024.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)

        {

            _userRepository = userRepository;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(UserViewModel uvm)
        {
            var result = _userRepository.CreateUser(uvm);

            if (result == "1")
            {
                return RedirectToAction("Login");
            }

            ViewBag.Message = "Failed to register! Username is already taken";

            return View();
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserViewModel uvm)
        {
            var user = _userRepository.LoginUser(uvm.UserName, uvm.Password);
            if (user != null)
            {
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

                var claimsIdentity = new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);

                AuthenticationProperties authProperties = new AuthenticationProperties();

                HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties
                    );
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Message = "Invalid Username/ Password";
            return View();

        }

        public IActionResult SignOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            //  return View("Login");

            return RedirectToAction("Index", "Home");
            
            
        }
    }

}