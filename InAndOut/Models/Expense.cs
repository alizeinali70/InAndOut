using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Models
{
    public class Expense
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("Expense")]
        [Required(ErrorMessage ="This Cannot Be empty")]
        public string ExpenseName { get; set; }
        [Required]
        [Range(1,int.MaxValue,ErrorMessage ="This Value is not Acceptable")]
        public int Amount { get; set; }
    }
}
