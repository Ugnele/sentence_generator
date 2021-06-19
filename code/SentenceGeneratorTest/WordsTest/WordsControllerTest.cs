using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration configuration;

        public WordsControllerTest()
        {
            configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json")
                .Build();
        }

        /// <summary>
        /// Checks if all four of speech parts are stored 5 words each
        /// </summary>
        [Fact]
        public void GetAllWordsTest()
        {
            WordsController words = new(configuration);
            Dictionary<string, List<string>> allWords = 
                words.GetAllWords().Value;
            Assert.True(allWords.Any());

            Assert.Equal(4, allWords.Keys.Count); //adjectives, adverbs, nouns and verbs
            foreach (List<string> speechPart in allWords.Values)
            {
                Assert.NotNull(speechPart);
                Assert.NotEmpty(speechPart);
            }

            Assert.True(allWords.Values.Count <= 5);
        }
    }
}
