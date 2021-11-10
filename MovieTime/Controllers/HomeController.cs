using Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Bson.Serialization;
using MovieTime.Helper;
using MovieTime.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MovieTime.Controllers
{
    public class HomeController : Controller
    {
        MovieAPI _api = new MovieAPI();

       
        public async Task<IActionResult> Index()
        {
            List<Movie> movie = new List<Movie>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/movie");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                movie = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Movie>>(result);
            }

            return View(movie);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
