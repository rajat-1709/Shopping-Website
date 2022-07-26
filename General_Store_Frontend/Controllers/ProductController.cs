using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using sampleshopping1frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace sampleshopping1frontend.Controllers
{
    public class ProductController : Controller
    {
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
                        var EmpResponse = Res.Content.ReadAsStringAsync().Result;

                        //Deserializing the response recieved from web api and storing into the Employee list  
                        ProductInfo = JsonConvert.DeserializeObject<List<Products>>(EmpResponse);

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
        [HttpGet]
        public async Task<IActionResult> GetProductDetailsByid(int id)
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

    }
}
