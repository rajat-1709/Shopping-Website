using System;
using System.Collections.Generic;

#nullable disable

namespace sampleshopping1.Models
{
    public partial class Product
    {
        public int Pid { get; set; }
        public string Pname { get; set; }
        public string Pdescription { get; set; }
        public int Price { get; set; }
        public int Pqty { get; set; }
        public string Pimageurl { get; set; }
        public bool? Pshow { get; set; }
    }
}
