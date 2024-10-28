using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Abstraction.Models
{
    public class Transaction : BaseClass
    {
        [Key]
        public int TransactionId { get; set; }
        public Nullable<int> BookId { get; set; }
        public string TransactionStatus { get; set; }
        public DateTime TransactionDate { get; set; }
        public int UserId { get; set; }
    }
}
