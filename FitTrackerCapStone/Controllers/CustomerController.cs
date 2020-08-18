using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using FitTrackerCapStone.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace FitTrackerCapStone.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CustomerController(ApplicationDbContext context)
        {
            _context = context;    
        }
        // GET: CustomerController
        public ActionResult Index()
        {
            ApiPost("bagel");
            return View();
        }

        public async void ApiPost(string request)
        {
            string apiKey = ApiKeys.nutritionApiKey;
            string apiId = ApiKeys.nurtitionAppId;
            string url = "https://trackapi.nutritionix.com/v2/natural/nutrients";
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("x-app-id", apiId);
            httpClient.DefaultRequestHeaders.Add("x-app-key", apiKey);

            Querys query = new Querys(request);
            var payload = JsonConvert.SerializeObject(query);
            HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");
            var httpResponse = await httpClient.PostAsync(url, content);
            if (httpResponse.IsSuccessStatusCode)
            {
                var data = await httpResponse.Content.ReadAsStringAsync();
                JObject jsonResult = JsonConvert.DeserializeObject<JObject>(data);
                JToken foods = jsonResult["foods"];
                Kitchen kitchen = new Kitchen(_context);
                kitchen.ReturnFoods(foods);

            }


            //var someinfo = JsonConvert.DeserializeObject<Food>(data);

            var number = 2;
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
