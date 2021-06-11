using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Sentence.Builder;

namespace Sentence.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SentenceController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetSentence()
        {
            var lengthService = "https://localhost:44380/length";
            var lengthResponceCall = await new HttpClient().GetStringAsync(lengthService);
            
            var wordsService = "https://localhost:44362/words";
            var wordsResponceCall = await new HttpClient().GetStringAsync(wordsService);

            SentenceBuilder sb = new();
            String sentence = sb.BuildSentence(wordsResponceCall, lengthResponceCall);

            return Ok(sentence);
        }
    }
}
