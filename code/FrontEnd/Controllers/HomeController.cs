using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FrontEnd.Models;
using System.Net.Http;

namespace FrontEnd.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var sentenceService = "https://localhost:44366/sentence";
            var sentenceResponceCall = await new HttpClient().GetStringAsync(sentenceService);
            ViewBag.responseCall = sentenceResponceCall;
            return View();
        }
    }
}
