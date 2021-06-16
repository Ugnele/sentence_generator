using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FrontEnd.Models;
using System.Net.Http;
using Microsoft.Extensions.Configuration;

namespace FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        private IConfiguration Configuration;

        public HomeController(IConfiguration config)
        {
            Configuration = config;
        }
        public async Task<IActionResult> Index()
        {
            //var sentenceService = "https://localhost:44366/sentence";
            var sentenceService = $"{Configuration["sentenceServiceURL"]}";
            var sentenceResponceCall = await new HttpClient().GetStringAsync(sentenceService);
            ViewBag.responseCall = sentenceResponceCall;
            return View();
        }
    }
}
