using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Sentence.Builder;

namespace Sentence.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SentenceController : ControllerBase
    {
        private readonly IConfiguration Configuration;
        private readonly HttpClient HttpClient;


        public SentenceController(IConfiguration config, HttpClient client)//
        {
            Configuration = config;
            HttpClient = client;
        }

        [HttpGet]
        public async Task<IActionResult> GetSentence()
        {
            var lengthService = $"{Configuration["lengthServiceURL"]}";
            var lengthResponceCall = await HttpClient.GetStringAsync(lengthService);
            
            var wordsService = $"{Configuration["wordsServiceURL"]}";
            var wordsResponceCall = await HttpClient.GetStringAsync(wordsService);

            SentenceBuilder sb = new();
            String sentence = sb.BuildSentence(wordsResponceCall, lengthResponceCall);

            return Ok(sentence.ToUpper());
        }
    }
}
