using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Words.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WordsController : ControllerBase
    {
        public string GetResourcesPath()
        {
            string path = Directory.GetCurrentDirectory();
            string parentPath = Path.GetFullPath(Path.Combine(path, @"..\..\..\"));
            string resourcesPath = Path.GetFullPath(Path.Combine(parentPath, @"resources\"));
            
            return resourcesPath;
        }
        public string[] ReadFile(string path, string wordsFile)
        {
            string file = wordsFile + ".txt";
            string wordsPath = Path.GetFullPath(Path.Combine(path, file));
            string[] words = System.IO.File.ReadAllLines(wordsPath);
            return words;
        }

        public List<string> GetRandomWords(string[] words)
        {
            List<string> randomWords = new();
            var random = new Random();
            int randomIndex;
            for (int w = 1; w <= 5; w++)
            {
                randomIndex = random.Next(0, words.Length);
                randomWords.Add(words[randomIndex]);
            }
            return randomWords;
        }

        [HttpGet]
        public ActionResult<List<string>[]> GetAllWords(string path)
        {
            //string path = GetResourcesPath();
            String[] adjectives = ReadFile(path, "adjectives");
            String[] adverbs = ReadFile(path, "adverbs");
            String[] nouns = ReadFile(path, "nouns");
            String[] verbs = ReadFile(path, "verbs");

            List<string>[] allWords =
            {
                GetRandomWords(adjectives),
                GetRandomWords(adverbs),
                GetRandomWords(nouns),
                GetRandomWords(verbs)
            };

            return allWords;
        }
    }
}
