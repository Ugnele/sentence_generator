using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Words.Controllers;
using Xunit;

namespace SentenceGeneratorTest.WordsTest
{
    public class WordsControllerTest
    {
        public string GetPath()
        {
            string path = Directory.GetCurrentDirectory();
            string parentPath = Path.GetFullPath(Path.Combine(path, @"..\..\..\..\"));
            return Path.GetFullPath(Path.Combine(parentPath, @"Words\resources\"));
        }

        [Fact]
        public void GetResourcesPathTest()
        {
            WordsController words = new();
            string parentPath = Path.GetFullPath(Path.Combine(words.GetResourcesPath(), @"..\"));
            Assert.True(Directory.Exists(parentPath));
        }

        /// Checks if file is read and stored into an array
        [Fact]
        public void ReadFileTest()
        {
            WordsController words = new();
            Assert.NotNull(words.ReadFile(GetPath(), "verbs"));
            Assert.Contains("zoom", words.ReadFile(GetPath(), "verbs"));
            Assert.Equal("Agenize", words.ReadFile(GetPath(), "verbs")[0]);
        }

        [Fact]
        public void GetRandomWordsTest()
        {
            WordsController words = new();
            String[] verbs = words.ReadFile(GetPath(), "verbs");

            Assert.True(words.GetRandomWords(verbs).Any());
            Assert.Equal(5, words.GetRandomWords(verbs).Count);

            string word = words.GetRandomWords(verbs).First();

            Assert.IsType<string>(word);

        }

    }
}
