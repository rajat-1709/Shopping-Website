using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace MicroCartApi.Models
{
    public partial class Order
    {
        [Key]
        public int Orderid { get; set; }
        public string Uname { get; set; }
        public int? Productid { get; set; }
        public string Productname { get; set; }
        public int? Productqty { get; set; }
        public int? Producttotal { get; set; }
        public DateTime? Productorderdate { get; set; }
        public DateTime? Deliverydate { get; set; }
    }
}
