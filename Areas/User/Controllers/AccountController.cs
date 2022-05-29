using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using RockFord.Application.Services.Interfaces;
using RockFord.DataLayer.DTOs.Account;
using RockFord.Web.Controllers;

namespace RockFord.Web.Areas.User.Controllers
{
    public class AccountController : UserBaseController 
    {
        #region constractor

        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        #region register
        [HttpGet("_Register")]
        public IActionResult _Register()
        {
            return View();
        }
        [HttpPost("_Register"), ValidateAntiForgeryToken]
        public async Task<IActionResult> _Register(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                var res = await _userService.RegisterUser(register);
                switch (res)
                {
                    case RegisterUserResult.UserExist:
                        TempData[WarningMessage] = "نام کاربری یا تلفن همراه تکراری است.";
                        break;
                    case RegisterUserResult.Success:
                        TempData[SuccessMessage] = "ثبت نام با موفقیت انجام شد";
                        var user = await _userService.GetUserByUserName(register.UserName);
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, user.UserName),
                            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                        };
                        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);
                        var properties = new AuthenticationProperties
                        {
                            IsPersistent = true
                        };
                        await HttpContext.SignInAsync(principal, properties);
                        return Redirect("/home");
                }
            }
            return View(register);
        }


        #endregion

        #region Login
        [HttpGet("_Login")]
        public IActionResult _Login()
        {
            return View();
        }
        [HttpPost("_Login"), ValidateAntiForgeryToken]
        public async Task<IActionResult> _Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                var log = await _userService.LoginUser(login);
                switch (log)
                {
                    case LoginUserResult.NotFound:
                        TempData[ErrorMessage] = "کاربری با این مشخصات یافت نشد";
                        break;
                    case LoginUserResult.Success:
                        var user = await _userService.GetUserByUserName(login.UserName);
                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, user.UserName),
                            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                        };
                        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);
                        var properties = new AuthenticationProperties
                        {
                            IsPersistent = true
                        };
                        await HttpContext.SignInAsync(principal, properties);
                        TempData[SuccessMessage] = "ورود با موفقیت انجام شد";
                        return Redirect("/home");

                }
            }
            TempData[ErrorMessage] = "کاربری با این مشخصات یافت نشد";
            return Redirect("/user");
        }

        #endregion

        #region Logout
        [HttpGet("LogOut")]
        public async Task<IActionResult> LogOut()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }

        #endregion
    }
}
