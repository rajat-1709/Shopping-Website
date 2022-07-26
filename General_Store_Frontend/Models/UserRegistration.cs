using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sampleshopping1frontend.Models
{
    public class UserRegistration
    {
        [Key]
        [Required(ErrorMessage = "Please Enter Your Username")]
        public string Uname { get; set; }
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please Enter Your Password")]
        public string Passwd { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please Enter Your Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Your First Name")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Please Enter Your Last Name")]
        public string Lastname { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Please Enter Your Phone Number")]
        public string Phonenumber { get; set; }
        [Required(ErrorMessage = "Please Enter Your City")]
        public string City { get; set; }
        [Required(ErrorMessage = "Please Enter Your Address")]
        public string Addressofuser { get; set; }
        [Required(ErrorMessage = "Please Enter Your Gender")]
        public string Gender { get; set; }
    }
}
