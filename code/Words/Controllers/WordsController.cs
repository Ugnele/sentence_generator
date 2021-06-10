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
        public ActionResult<Dictionary<string, List<string>>> GetAllWords()
        {
            FileReader fr = new();
            string path = fr.GetResourcesPath();
            String[] adjectives = fr.ReadFile(path, "adjectives");
            String[] adverbs = fr.ReadFile(path, "adverbs");
            String[] nouns = fr.ReadFile(path, "nouns");
            String[] verbs = fr.ReadFile(path, "verbs");

            Dictionary<string, List<string>> allWords = new();
            allWords.Add("adjectives", fr.GetRandomWords(adjectives, "adjectives"));
            allWords.Add("adverbs", fr.GetRandomWords(adverbs, "adverbs"));
            allWords.Add("nouns", fr.GetRandomWords(nouns, "nouns"));
            allWords.Add("verbs", fr.GetRandomWords(verbs, "verbs"));

            return allWords;
        }

        // this method is only used for testing purposes
        [HttpGet]
        [Route("testing")]
        public ActionResult<Dictionary<string, List<string>>> GetAllWordsForTesting(string path)
        {
            FileReader fr = new();
            String[] adjectives = fr.ReadFile(path, "adjectives");
            String[] adverbs = fr.ReadFile(path, "adverbs");
            String[] nouns = fr.ReadFile(path, "nouns");
            String[] verbs = fr.ReadFile(path, "verbs");

            Dictionary<string, List<string>> allWords = new();
            allWords.Add("adjectives", fr.GetRandomWords(adjectives, "adjectives"));
            allWords.Add("adverbs", fr.GetRandomWords(adverbs, "adverbs"));
            allWords.Add("nouns", fr.GetRandomWords(nouns, "nouns"));
            allWords.Add("verbs", fr.GetRandomWords(verbs, "verbs"));

            return allWords;
        }
    }
}
