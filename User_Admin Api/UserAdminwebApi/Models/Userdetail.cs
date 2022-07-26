using System;
using System.Collections.Generic;

#nullable disable

namespace UserAdminwebApi.Models
{
    public partial class Userdetail
    {
        public int Userid { get; set; }
        public string Uname { get; set; }
        public string Passwd { get; set; }
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Phonenumber { get; set; }
        public string City { get; set; }
        public string Addressofuser { get; set; }
        public string Gender { get; set; }
        public int? Useractive { get; set; }
    }
}
