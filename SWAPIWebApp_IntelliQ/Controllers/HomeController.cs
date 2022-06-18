using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SWAPIWebApp_IntelliQ.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SWAPIWebApp_IntelliQ.Controllers
{
    public class HomeController : Controller
    {
        private const string BaseUrl = "https://swapi.dev/api/";

        public async Task<ActionResult> Index(int page)
        {
            Result results = new Result();
            List<Person> people = new List<Person>();

            using (HttpClient client = new HttpClient())
            {
                if (page <= 0)
                {
                    page = 1;
                }

                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync($"people/?page={page}");

                if (res.IsSuccessStatusCode)
                {
                    string response = await res.Content.ReadAsStringAsync();
                    results = JsonConvert.DeserializeObject<Result>(response);
                    people = results.Results.ToList();

                    if (people.Count() <= 0)
                    {
                        ViewBag.Message = "Error Retrieving People";
                    }
                }

                return View(people);
            }
        }
    }
}
