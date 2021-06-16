using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Words.Reader
{
    public class FileReader
    {
        public string GetResourcesPath()
        {

            string exePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().CodeBase);
            Regex appPathMatcher = new Regex(@"(?<!fil)[A-Za-z]:\\+[\S\s]*?(?=\\+bin)");
            string appRoot = appPathMatcher.Match(exePath).Value;

            string resourcesPath = Path.GetFullPath(Path.Combine(appRoot, @"resources\"));

            return resourcesPath;
        }

        public string[] ReadFile(string path, string wordsFile)
        {
            string file = wordsFile + ".txt";//
            string wordsPath = Path.GetFullPath(Path.Combine(path, file));
            string[] words = System.IO.File.ReadAllLines(wordsPath);
            return words;
        }

        public List<string> GetRandomWords(string[] words, string key)
        {
            var random = new Random();
            int randomIndex;
            List<string> selectedWords = new();
            if(key.Equals("nouns"))
            {
                randomIndex = random.Next(0, words.Length);
                selectedWords.Add(words[randomIndex]);
            }
            randomIndex = random.Next(0, words.Length);
            selectedWords.Add(words[randomIndex]);
            
            return selectedWords;
        }
    }
}
