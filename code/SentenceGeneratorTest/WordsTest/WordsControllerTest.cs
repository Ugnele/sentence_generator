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

        /// <summary>
        /// Checks if the path for words resources is obtained
        /// </summary>
        [Fact]
        public void GetResourcesPathTest()
        {
            WordsController words = new();
            string parentPath = Path.GetFullPath(Path.Combine(words.GetResourcesPath(), @"..\"));
            Assert.True(Directory.Exists(parentPath));
        }

        /// <summary>
        /// Checks if file is read and stored into an array
        /// </summary>
        [Fact]
        public void ReadFileTest()
        {
            WordsController words = new();
            Assert.NotNull(words.ReadFile(GetPath(), "verbs"));
            Assert.Contains("zoom", words.ReadFile(GetPath(), "verbs"));
            Assert.Equal("Agenize", words.ReadFile(GetPath(), "verbs")[0]);
        }

        /// <summary>
        /// Checks if 5 random words are stored into a list
        /// </summary>
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

        /// <summary>
        /// Checks if all four of speech parts are stored 5 words each
        /// </summary>
        [Fact]
        public void GetAllWordsTest()
        {
            WordsController words = new();
            Assert.True(words.GetAllWords(GetPath()).Any());
            Assert.Equal(4, words.GetAllWords(GetPath()).Length); //adjectives, adverbs, nouns and verbs
            foreach (List<string> speechPart in words.GetAllWords(GetPath()))
            {
                Assert.NotNull(speechPart);
                Assert.Equal(5, speechPart.Count);
            }
        }
    }
}
