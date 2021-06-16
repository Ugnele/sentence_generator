using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Sentence.Builder;

namespace Sentence.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SentenceController : ControllerBase
    {
        private IConfiguration Configuration;

        public SentenceController(IConfiguration config)
        {
            Configuration = config;
        }

        [HttpGet]
        public async Task<IActionResult> GetSentence()
        {
            var lengthService = $"{Configuration["lengthServiceURL"]}";
            var lengthResponceCall = await new HttpClient().GetStringAsync(lengthService);
            
            var wordsService = $"{Configuration["wordsServiceURL"]}";
            var wordsResponceCall = await new HttpClient().GetStringAsync(wordsService);

            SentenceBuilder sb = new();
            String sentence = sb.BuildSentence(wordsResponceCall, lengthResponceCall);

            return Ok(sentence);
        }
    }
}
