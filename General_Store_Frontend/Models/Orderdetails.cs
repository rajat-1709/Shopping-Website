using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sampleshopping1frontend.Models
{
    public class Orderdetails
    {
        [Key]
        public int orderid { get; set; }
    
        public string uname { get; set; }
        public int productid { get; set; }
        public string Productname { get; set; }
        public int Productqty { get; set; }
        public int productTotal { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime productorderdate { get; set; }
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime deliverydate { get; set; }




    }
}
