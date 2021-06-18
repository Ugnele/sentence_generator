using Microsoft.Extensions.Configuration;
using Microsoft.WindowsAzure.Storage;
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
        private readonly string connectionString;

        public FileReaderTest()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.test.json")
                .Build();

            connectionString = configuration.GetValue<string>("StorageConnectionString");
        }

        [Fact]
        public void ReadBlobContentsTest()
        {
            FileReader reader = new();
            
            Assert.NotNull(reader.ReadBlobContents(connectionString, "adjectives.txt"));

            Assert.NotNull(reader.storageAccount);
            Assert.Equal("project", reader.container.Name.ToString());
            Assert.NotNull(reader.container.GetBlobReference("adjectives.txt")); Assert.NotNull(reader.ReadBlobContents(connectionString, "adjectives.txt"));
            
        }
        
        [Fact]
        public void ReadFileTest()
        {
            FileReader reader = new();
            Assert.NotNull(reader.ReadFile(connectionString, "verbs"));
            Assert.Contains("zoom", reader.ReadFile(connectionString, "verbs"));
            Assert.Equal("Agenize", reader.ReadFile(connectionString, "verbs")[0]);
        }
        
        [Fact]
        public void GetRandomWordsTest()
        {
            FileReader reader = new();
            String[] verbs = reader.ReadFile(connectionString, "verbs");

            Assert.True(reader.GetRandomWords(verbs, "verbs").Any());
            Assert.IsType<List<string>>(reader.GetRandomWords(verbs, "verbs"));

            int countValues = reader.GetRandomWords(verbs, "verbs").Count;
            Assert.Equal(1, countValues);

            String[] nouns = reader.ReadFile(connectionString, "nouns");
            countValues = reader.GetRandomWords(nouns, "nouns").Count;
            Assert.Equal(2, countValues);

            string word = reader.GetRandomWords(verbs, "verbs").First();
            Assert.IsType<string>(word);
        }

    }
}
