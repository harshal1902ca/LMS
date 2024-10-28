using LMS.Abstraction.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JsonIgnoreRequest = System.Text.Json.Serialization.JsonIgnoreAttribute;
using JsonIgnoreResponse = Newtonsoft.Json.JsonIgnoreAttribute;

namespace LMS.Abstraction.Models
{
    public class User : BaseClass
    {
        [Key]
        public long UserId { get; set; }

        [EmailAddress(ErrorMessage = "Please enter valid email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please enter first name")]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "Please enter valid mobile no")]
        [StringLength(10, ErrorMessage = "Please enter valid mobile no", MinimumLength = 10)]
        [MaxLength(10)]
        public string MobileNo { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }
        public bool IsAdmin { get; set; }
    }
}
