using ConsumeAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace ConsumeAPI.Controllers
{
    public class CustomerController : Controller
    {
        Customer _cus = new Customer();
        private readonly IConfiguration _iconfiguration;
        public CustomerController(IConfiguration iconfiguration)
        {
            _iconfiguration = iconfiguration;
        }
        public async Task<IActionResult> Index()
        {
            string dbConn = _iconfiguration.GetSection("APIURL").Value;
            List<Customer> cusList = new List<Customer>();
            using (var httpClient = new HttpClient())  // For avoiding "The SSL connection could not be established see inner Exception" we have to use "HttpClientHandle".
            {
                using (var response = await httpClient.GetAsync(dbConn))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync(); //JSON
                        cusList = JsonConvert.DeserializeObject<List<Customer>>(apiResponse); // Object
                    }
                }
            }
            return View(cusList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Customer cusObj)
        {
            string dbConn = _iconfiguration.GetSection("APIURL").Value;
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(cusObj), Encoding.UTF8, "application/json"); // Object to JSON
                using (var response = await httpClient.PostAsync(dbConn, content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
                return View();
            }
        }
        public async Task<ActionResult> Edit(int id)
        {
            _cus = new Customer();
            string dbConn = _iconfiguration.GetSection("APIURL").Value;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(dbConn + id))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        _cus = JsonConvert.DeserializeObject<Customer>(apiResponse);
                    }
                }
            }
            return View(_cus);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Customer cusObj)
        {
            string dbConn = _iconfiguration.GetSection("APIURL").Value;
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(cusObj), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync(dbConn, content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
                return View();
            }
        }

        [HttpGet]
        public async Task<ActionResult> Details(int id)
        {
            _cus = new Customer();
            string dbConn = _iconfiguration.GetSection("APIURL").Value;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(dbConn + id))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        _cus = JsonConvert.DeserializeObject<Customer>(apiResponse);
                    }
                }
            }
            return View(_cus);
        }
        [HttpGet]
        public async Task<ActionResult> Delete(int id)
        {
            string dbConn = _iconfiguration.GetSection("APIURL").Value;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync(dbConn+ "?cid=" +id))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            return RedirectToAction("Index");
        }
    }
}
