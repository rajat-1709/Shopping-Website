using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sampleshopping1frontend.Models
{
    public class Products
    {
        [Key]
        public int Pid { get; set; }
        public string Pname { get; set; }
        public string Pdescription { get; set; }
        public int Price { get; set; }
        public int Pqty { get; set; }
        public string Pimageurl { get; set; }
        public bool? Pshow { get; set; }

    }
}
