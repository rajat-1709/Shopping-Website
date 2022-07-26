using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sampleshopping1frontend.Models
{
    public class Admin
    {
        [Key]
        public string Username { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please Enter Your Password")]
        public string Password { get; set; }



    }
}
