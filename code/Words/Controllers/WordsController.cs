using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Words.Reader;

namespace Words.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class WordsController : ControllerBase
    {

        [HttpGet]
        public ActionResult<List<string>[]> GetAllWords()//string path
        {
            FileReader fr = new();
            string path = fr.GetResourcesPath();
            String[] adjectives = fr.ReadFile(path, "adjectives");
            String[] adverbs = fr.ReadFile(path, "adverbs");
            String[] nouns = fr.ReadFile(path, "nouns");
            String[] verbs = fr.ReadFile(path, "verbs");

            List<string>[] allWords =
            {
                fr.GetRandomWords(adjectives),
                fr.GetRandomWords(adverbs),
                fr.GetRandomWords(nouns),
                fr.GetRandomWords(verbs)
            };

            return allWords;
        }

        // this method is only used for testing purposes
        [HttpGet]
        [Route("testing")]
        public ActionResult<List<string>[]> GetAllWordsForTesting(string path)
        {
            FileReader fr = new();
            String[] adjectives = fr.ReadFile(path, "adjectives");
            String[] adverbs = fr.ReadFile(path, "adverbs");
            String[] nouns = fr.ReadFile(path, "nouns");
            String[] verbs = fr.ReadFile(path, "verbs");

            List<string>[] allWords =
            {
                fr.GetRandomWords(adjectives),
                fr.GetRandomWords(adverbs),
                fr.GetRandomWords(nouns),
                fr.GetRandomWords(verbs)
            };

            return allWords;
        }
    }
}
