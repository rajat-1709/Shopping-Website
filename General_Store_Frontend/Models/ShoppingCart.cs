using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace sampleshopping1frontend.Models
{
    public class ShoppingCart
    {
        public int Pid  { get; set; }
        public string pname { get; set; }
        [Key]
        public string uname { get; set; }

        public int pprice { get; set; }

        public int quant { get; set; }


        public int Tprice { get; set; }

        public int itemPaidSuccesfully { get; set; }

        public ShoppingCart()
        {

        }

        public ShoppingCart(int pid, string pname, int quant,int pprice,int Tprice,string uname)
        {
            this.Pid = pid;
            this.pname = pname;
            this.quant = quant;
            this.pprice = pprice;
            this.Tprice = Tprice;
            this.uname = uname;
            this.itemPaidSuccesfully = 0;
        }
    }
}
