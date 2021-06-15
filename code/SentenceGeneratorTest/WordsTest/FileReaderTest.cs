using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Words.Reader;
using Xunit;

namespace SentenceGeneratorTest.WordsTest
{
    public class FileReaderTest
    {
        /// <summary>
        /// Checks if the path for words resources is obtained
        /// </summary>
        [Fact]
        public void GetResourcesPathTest()
        {
            FileReader reader = new();
            Assert.True(Directory.Exists(reader.GetResourcesPath()));
        }

        /// <summary>
        /// Checks if file is read and stored into an array
        /// </summary>
        [Fact]
        public void ReadFileTest()
        {
            FileReader reader = new();
            Assert.NotNull(reader.ReadFile(reader.GetResourcesPath(), "verbs"));
            Assert.Contains("zoom", reader.ReadFile(reader.GetResourcesPath(), "verbs"));
            Assert.Equal("Agenize", reader.ReadFile(reader.GetResourcesPath(), "verbs")[0]);
        }

        /// <summary>
        /// Checks if 5 random words are stored into a list
        /// </summary>
        [Fact]
        public void GetRandomWordsTest()
        {
            FileReader reader = new();
            String[] verbs = reader.ReadFile(reader.GetResourcesPath(), "verbs");

            Assert.True(reader.GetRandomWords(verbs, "verbs").Any());

            int countValues = reader.GetRandomWords(verbs, "verbs").Count;
            Assert.Equal(1, countValues);

            String[] nouns = reader.ReadFile(reader.GetResourcesPath(), "nouns");
            countValues = reader.GetRandomWords(nouns, "nouns").Count;
            Assert.Equal(2, countValues);

            string word = reader.GetRandomWords(verbs, "verbs").First();
            Assert.IsType<string>(word);
        }
    }
}
