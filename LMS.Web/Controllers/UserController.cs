using Core.Repository.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using LMS.Abstraction.ComplexModels;
using LMS.Abstraction.Enums;
using LMS.Abstraction.Models;
using LMS.Service.Interfaces;
using LMS.Web.Models;
using System.Security.Claims;
using Core.Repository.Constants;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Data;

namespace LMS.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserProviderService _userProviderService;

        public UserController(
           IUserService userService,
           IUserProviderService userProviderService
        )
        {
            _userService = userService;
            _userProviderService = userProviderService;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginModel login)
        {

            var userResult = await _userService.AuthenticateUser(login);
            if (userResult.Success)
            {
                var user = userResult.Data as User;

                var claims = new[]
                {
                    new Claim(CustomClaimTypes.UserId, user.UserId.ToString()),
                    new Claim(CustomClaimTypes.Username, $"{user.FirstName}"),
                    //new Claim(CustomClaimTypes.RoleIds, string.Join(",", roles)),
                    
                    new Claim(CustomClaimTypes.IsAdmin, user.IsAdmin.ToString()),
                    new Claim(CustomClaimTypes.SessionId, userResult.Success ? (userResult.Data as User).UserId.ToString() : ""),
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), new AuthenticationProperties
                {
                    IsPersistent = false,
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(60),
                });

                if (!string.IsNullOrEmpty(login.ReturnUrl) && login.ReturnUrl != "/Logout" && Url.IsLocalUrl(login.ReturnUrl))
                {
                    return Redirect(login.ReturnUrl);
                }
                else
                {
                    
                    if (user.IsAdmin)
                    {
                        return RedirectToAction("Index", "Book");
                    }
                    return RedirectToAction("Index", "Book");
                }
            }
            return View();
        }
        [HttpGet]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await ClearSession();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Manage(long id = 0)
        {
            //if (!AuthorizeUser()) { return AccessDeniedView(); }

            var model = new User();
            if (id > 0)
            {
                var userResult = await _userService.GetUserById(id);
                if (userResult.Success)
                {
                    model = userResult.Data;
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Manage(User model)
        {
            ResponseModel userResult;
            if (model.UserId == 0)
            {
                userResult = await _userService.CreateUser(model);
            }
            else
            {
                userResult = await _userService.UpdateUser(model);
            }

            if (userResult.Success)
            {
                //SetNotification($"User saved successfully!", NotificationTypes.Success, "User");
                return RedirectToAction("Index", "User");
            }
            return View(model);
        }

        private bool AuthorizeUser()
        {
            return _userProviderService.IsAuthenticated();
        }
        private async Task ClearSession()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme, new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTime.UtcNow.AddDays(-1)
            });
            _userProviderService.RemoveSessionUser();
        }
    }
}
