using System;
using System.Collections.Generic;

namespace Core.Repository.Models
{
    public class UserClaim
    {
        public int UserId { get; set; }
        public bool IsAdmin { get; set; }
        public List<long> RoleIds { get; set; } = new List<long>();
        public string Username { get; set; }
        public string RoleName { get; set; }
        public string SessionId { get; set; }
    }
}
