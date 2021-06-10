﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Words.Reader
{
    public class FileReader
    {
        public string GetResourcesPath()
        {
            string path = Directory.GetCurrentDirectory();
            string resourcesPath = Path.GetFullPath(Path.Combine(path, @"resources\"));

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
    }
}