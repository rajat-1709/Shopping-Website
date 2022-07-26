using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using sampleshopping1frontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace sampleshopping1frontend.Controllers
{
    public class UserLoginController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> login(UserLogin l)
        {
            UserLogin userobj = new UserLogin();
            using (var httpClient = new HttpClient())
            {
                //StringContent content = new StringContent(JsonConvert.SerializeObject(l), Encoding.UTF8, "application/json");

                using (var response = await httpClient.GetAsync("https://localhost:44378/api/Userdetails/" + l.Uname + "/" + l.Password))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    userobj = JsonConvert.DeserializeObject<UserLogin>(apiResponse);
                }
            }
            if (userobj.Uname != null)
            {
                string username = l.Uname;
                HttpContext.Session.SetString("uname", username);
                return RedirectToAction("ProductDetails", "Product");
            }
            else
            {
                return View();
            }

        }
        [HttpGet]
        public async Task<IActionResult> RegisterUserForlogin()
        {
            return View();
        }

        public async Task<IActionResult> RegisterUserForloginConfirmation()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> MyAccount()
        {
            string uname = HttpContext.Session.GetString("uname");
            UserRegistration user_reg = new UserRegistration();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44378/api/Userdetails/" + uname))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    user_reg = JsonConvert.DeserializeObject<UserRegistration>(apiResponse);
                }
            }
            return View(user_reg);
            
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUserForlogin(UserRegistration ul)
        {

            //UserRegistration robj = new UserRegistration();
            using (var httpClient = new HttpClient())
           
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(ul), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://localhost:44378/api/Userdetails", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                  // UserRegistration robj = JsonConvert.DeserializeObject<UserRegistration>(apiResponse);
                }
            }

            return RedirectToAction("RegisterUserForloginConfirmation");
        }

        public IActionResult logout()
        {

            HttpContext.Session.Clear();
            return RedirectToAction("login");
        }
    }
}
