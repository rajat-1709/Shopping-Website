using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using sampleshopping1frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace sampleshopping1frontend.Controllers
{
    public class CartController : Controller
    {
        public static List<ShoppingCart> temp_gc = new List<ShoppingCart>();
        public static List<ShoppingCart> result = new List<ShoppingCart>();

        public async Task<IActionResult> NoItemsinCart()
        {
            return View();
        }

        public async Task<IActionResult> Index()
        {
            //string uname = "demo";
            string uname = HttpContext.Session.GetString("uname");
            if (uname != null)
            {
                if (result.Any(model => model.uname == uname /*&& model.itemPaidSuccesfully==0*/))
                {
                    return View(result);
                }
                else
                {
                    return RedirectToAction("NoItemsinCart");
                }
            }
            else
            {
                return RedirectToAction("login","UserLogin");
            }
        }

        public async Task<IActionResult> Myorder()
        {
            string uname = HttpContext.Session.GetString("uname");
            try
            {
                List<Orderdetails> OrderInfo = new List<Orderdetails>();
                using (var client = new HttpClient())
                {
                    //Passing service base url  
                    client.DefaultRequestHeaders.Clear();
                    //Define request data format  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                    HttpResponseMessage Res = await client.GetAsync("https://localhost:44368/api/Orders/"+uname);

                    //Checking the response is successful or not which is sent using HttpClient  
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list  
                        OrderInfo = JsonConvert.DeserializeObject<List<Orderdetails>>(EmpResponse);

                    }
                    //returning the employee list to view  
                    return View(OrderInfo);
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }



        }
     
        public async Task<IActionResult> AddOrder()
        {
            Orderdetails op = new Orderdetails();
            //string uname = "demo";
            string uname = HttpContext.Session.GetString("uname");
            ViewBag.Username = uname;
            foreach (var item in result)
            {
                
                if (item.uname == uname)
                {
                    if (item.itemPaidSuccesfully == 0)
                    {
                        {
                            op.productid = item.Pid;
                            op.Productname = item.pname;
                            op.Productqty = item.quant;
                            op.productorderdate = DateTime.Now;
                            op.deliverydate = DateTime.Now.AddDays(7);
                            op.uname = uname;
                            op.productTotal = item.Tprice;
                            item.itemPaidSuccesfully = 1;
                            

                            Orderdetails prodobj = new Orderdetails();
                            using (var httpClient = new HttpClient())
                            {
                                StringContent content = new StringContent(JsonConvert.SerializeObject(op), Encoding.UTF8, "application/json");

                                using (var response = await httpClient.PostAsync("https://localhost:44368/api/Orders", content))
                                {
                                    string apiResponse = await response.Content.ReadAsStringAsync();
                                    prodobj = JsonConvert.DeserializeObject<Orderdetails>(apiResponse);
                                }
                            }
                         
                        }
                    }
                }
            }
            temp_gc.RemoveAll(x => x.uname == uname );
            result.RemoveAll(x => x.uname == uname);

            //for (int i = result.Count - 1; i >= 0; i--)
            //{

            //        result.RemoveAt(i);
            //}
            //foreach (var item in result.ToList())
            //{

            //    //if (item.uname == uname)
            //    //{
            //    //    if (item.itemPaidSuccesfully == 1)
            //    //    {
            //    //        {
            //                result.Remove(item);
            //    //        }
            //    //    }
            //    //}
            //}
            return View();
        }

        public async Task<ActionResult> MakePayment(int tprice)
        {
            ViewBag.TotalPayment = tprice;

            return View();
        }
        public async Task<ActionResult> AddItem(int pid, string pname, int pprice)
        {
            //string uname = "demo";
            string uname = HttpContext.Session.GetString("uname");
            if (uname != null)
            {


                if (temp_gc.Any(model => model.Pid == pid && model.uname == uname))
                {
                    var n = from i in temp_gc where i.Pid == pid select i;
                    n.First().quant = n.First().quant + 1;
                    n.First().Tprice = n.First().Tprice * n.First().quant;
                }
                else
                {
                    int tprice = pprice * 1;
                    temp_gc.Add(new ShoppingCart(pid, pname, 1, pprice, tprice, uname));
                }

                foreach (var item in temp_gc)
                {
                    result = temp_gc.Where(e => e.uname == uname).ToList();
                }
                
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.GetAsync("https://localhost:44335/prod/" + pid))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        int ps =Convert.ToInt32(apiResponse);
                       
                    }
                }
               
                return RedirectToAction("Index");
               // return View(result);
            }
            else
            {
                return RedirectToAction("login","UserLogin");
            }
        }
    }
}
