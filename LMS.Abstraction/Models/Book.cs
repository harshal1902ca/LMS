using LMS.Abstraction.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JsonIgnoreRequest = System.Text.Json.Serialization.JsonIgnoreAttribute;
using JsonIgnoreResponse = Newtonsoft.Json.JsonIgnoreAttribute;

namespace LMS.Abstraction.Models
{
    public class Book : BaseClass
    {
        public int BookId { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 4, ErrorMessage = "The Title field must be between 4 and 30 character")]
        [DisplayName("BookTitle")]
        public string BookTitle { get; set; }

        [Required]
        [DisplayName("BookCategory")]
        public string BookCategory { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 4, ErrorMessage = "The Author field must be between 4 and 30 character")]
        [DisplayName("BookAuthor")]
        public string BookAuthor { get; set; }

        [Required]
        [DisplayName("DateAdded")]
        public DateTime DateAdded { get; set; }

        [Required]
        [DisplayName("Status")]
        public string Status { get; set; }

        [Required]
        [DisplayName("BookCopies")]
        public int BookCopies { get; set; }
    }
}
