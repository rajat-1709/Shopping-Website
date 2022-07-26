using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace sampleshopping1frontend.Models
{
    public class UserLogin
    {
        [Key]
        [Required(ErrorMessage = "Please Enter Your Username")]
        public string Uname { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please Enter Your Password")]
        public string Password { get; set; }
    }
}
