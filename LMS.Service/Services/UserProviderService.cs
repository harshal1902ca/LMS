using Core.Repository.Constants;
using Core.Repository.Models;
using Core.Utility.Utils;
using LMS.Abstraction.Enums;
using LMS.Service.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Service.Services
{
    public class UserProviderService : IUserProviderService
    {
        private readonly IHttpContextAccessor _context;

        public UserProviderService(IHttpContextAccessor context)
        {
            _context = context;
        }

        public UserClaim UserClaim => GetUserClaim();
        public bool IsAuthenticated() => _context.HttpContext.User.Identity == null ? false : _context.HttpContext.User.Identity.IsAuthenticated;



        public void RemoveSessionUser()
        {
            _context.HttpContext.User = new ClaimsPrincipal();
        }

        private UserClaim GetUserClaim()
        {
            var userClaims = new UserClaim();

            var name = _context.HttpContext.User.Claims.FirstOrDefault(i => i.Type == CustomClaimTypes.Username);
            if (name != null) { userClaims.Username = name.Value; }

            var userId = _context.HttpContext.User.Claims.FirstOrDefault(i => i.Type == CustomClaimTypes.UserId);
            if (userId != null && !string.IsNullOrEmpty(userId.Value)) { userClaims.UserId = Convert.ToInt32(userId.Value); }

            var isAdmin = _context.HttpContext.User.Claims.FirstOrDefault(i => i.Type == CustomClaimTypes.IsAdmin);
            if (isAdmin != null && !string.IsNullOrEmpty(isAdmin.Value)) { userClaims.IsAdmin = Convert.ToBoolean(isAdmin.Value); }

            var sessionId = _context.HttpContext.User.Claims.FirstOrDefault(i => i.Type == CustomClaimTypes.SessionId);
            if (sessionId != null) { userClaims.SessionId = sessionId.Value; }

            var roleIds = _context.HttpContext.User.Claims.FirstOrDefault(i => i.Type == CustomClaimTypes.RoleIds);
            if (roleIds != null && !string.IsNullOrEmpty(roleIds.Value)) { userClaims.RoleIds = roleIds.Value.Split(',').Select(long.Parse).ToList(); }

            if (userClaims.IsAdmin)
            {
                userClaims.RoleName = "Admin";
            }
            return userClaims;
        }

    }
}
