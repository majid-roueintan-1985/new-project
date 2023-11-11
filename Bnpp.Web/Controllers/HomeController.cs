using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Bnpp.Core.Services.Interfaces;
using Bnpp.Core.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Bnpp.Web.Controllers
{
    public class HomeController : Controller
    {
        private IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        #region Login

        //[Route("Login")]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        //[Route("Login")]
        public ActionResult Login(LoginViewModel login/*, string ReturnUrl = "/"*/)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }

            var user = _userService.LoginUser(login);
            if (user != null)
            {
                if (user.IsActive)
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                        new Claim(ClaimTypes.Name,user.UserName)
                    };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);

                    var properties = new AuthenticationProperties
                    {
                        IsPersistent = login.RememberMe
                    };
                    HttpContext.SignInAsync(principal, properties);

                    ViewBag.IsSuccess = true;
                    //if (ReturnUrl != "/")
                    //{
                    //    return Redirect(ReturnUrl);
                    //}
                    return View();
                }
                else
                {
                    ModelState.AddModelError("UserName", "Your Account Is Not Active");
                }
            }
            ModelState.AddModelError("UserName", "User Not Found");
            return View(login);
        }

        #endregion
        #region Logout
        [Route("Logout")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }

        #endregion

        [Route("Access Denied")]
        public IActionResult Error404()
        {
            return View();
        }
    }
}
