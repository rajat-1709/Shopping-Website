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
    public class AdminController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Adminlogin()
        {
           

                return View();
           
        }

        [HttpPost]
        public async Task<IActionResult> Adminlogin(Admin A)
        {
            Admin adminobj = new Admin();
            using (var httpClient = new HttpClient())
            {
                //StringContent content = new StringContent(JsonConvert.SerializeObject(l), Encoding.UTF8, "application/json");

                using (var response = await httpClient.GetAsync("https://localhost:44378/api/Admindetails/" + A.Username + "/" + A.Password))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    adminobj = JsonConvert.DeserializeObject<Admin>(apiResponse);
                }
            }
            if (adminobj.Username != null)
            {
                string username = A.Username;
                HttpContext.Session.SetString("uname", username);
                return RedirectToAction("Adminhome");
            }
            else
            {
                return View();
            }



        }

        public async Task<IActionResult> AllOrdersDetails()
        {
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
                    HttpResponseMessage Res = await client.GetAsync("https://localhost:44368/api/Orders");

                    //Checking the response is successful or not which is sent using HttpClient  
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var OrderResponse = Res.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list  
                        OrderInfo = JsonConvert.DeserializeObject<List<Orderdetails>>(OrderResponse);

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

        public IActionResult Logout()
        {

            HttpContext.Session.Clear();
            return RedirectToAction("Adminlogin");
        }

        public async Task<IActionResult> AdminHomeAsync()
        {
            int ts;
            using (var httpClient = new HttpClient())
            {

                using (var response = await httpClient.GetAsync("https://localhost:44368/api/Orders/TotalSales"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ts = JsonConvert.DeserializeObject<int>(apiResponse);
                }
            }
            ViewBag.tsales = ts;
            return View();
        }

        [HttpGet]
        public async Task<ActionResult> UpdateProduct(int id)
        {
            Products ps = new Products();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44335/api/Products/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ps = JsonConvert.DeserializeObject<Products>(apiResponse);
                }
            }
            return View(ps);
        }

        public async Task<ActionResult> UpdateProduct(Products p)
        {
            Products receivedemp = new Products();

            using (var httpClient = new HttpClient())
            {
                #region
            
                #endregion
                int id = p.Pid;
                StringContent content1 = new StringContent(JsonConvert.SerializeObject(p), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync("https://localhost:44335/api/Products/" + id, content1))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Success";
                    receivedemp = JsonConvert.DeserializeObject<Products>(apiResponse);
                }
            }
            return RedirectToAction("ProductDetails");
        }

        [HttpGet]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            Products ps = new Products();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44335/api/Products/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ps = JsonConvert.DeserializeObject<Products>(apiResponse);
                }
            }
            return View(ps);
        }


        [HttpPost]
        // [ActionName("DeleteProduct")]
        public async Task<ActionResult> DeleteProduct(Products p)
        {
            int id = p.Pid;
            //int prid = Convert.ToInt32(TempData["Pid"]);
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:44335/api/Products/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("Productdetails");
        }
        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(Products p)
        {
            Products prodobj = new Products();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(p), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:44335/api/Products", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    prodobj = JsonConvert.DeserializeObject<Products>(apiResponse);
                }
            }
            return RedirectToAction("ProductDetails");

        }

        public async Task<IActionResult> ProductDetails()
        {
            try
            {
                List<Products> ProductInfo = new List<Products>();
                using (var client = new HttpClient())
                {
                    //Passing service base url  
                    client.DefaultRequestHeaders.Clear();
                    //Define request data format  
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                    HttpResponseMessage Res = await client.GetAsync("https://localhost:44335/api/Products");

                    //Checking the response is successful or not which is sent using HttpClient  
                    if (Res.IsSuccessStatusCode)
                    {
                        //Storing the response details recieved from web api   
                        var PrdResponse = Res.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list  
                        ProductInfo = JsonConvert.DeserializeObject<List<Products>>(PrdResponse);

                    }
                    //returning the employee list to view  
                    return View(ProductInfo);
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Error", "Home");
            }
        }
    }


}
