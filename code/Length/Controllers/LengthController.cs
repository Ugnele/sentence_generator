using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Length.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LengthController : ControllerBase
    {

        [HttpGet]
        public int GetSentenceLength()
        {
            var random = new Random();
            int sentenceLength = random.Next(1, 5);
            return sentenceLength;
        }
    }
}
