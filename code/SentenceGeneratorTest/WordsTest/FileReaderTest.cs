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
        public static string GetPath()
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
            FileReader reader = new();
            string parentPath = Path.GetFullPath(Path.Combine(reader.GetResourcesPath(), @"..\"));
            Assert.True(Directory.Exists(parentPath));
        }

        /// <summary>
        /// Checks if file is read and stored into an array
        /// </summary>
        [Fact]
        public void ReadFileTest()
        {
            FileReader reader = new();
            Assert.NotNull(reader.ReadFile(GetPath(), "verbs"));
            Assert.Contains("zoom", reader.ReadFile(GetPath(), "verbs"));
            Assert.Equal("Agenize", reader.ReadFile(GetPath(), "verbs")[0]);
        }

        /// <summary>
        /// Checks if 5 random words are stored into a list
        /// </summary>
        [Fact]
        public void GetRandomWordsTest()
        {
            FileReader reader = new();
            String[] verbs = reader.ReadFile(GetPath(), "verbs");

            Assert.True(reader.GetRandomWords(verbs).Any());
            Assert.Equal(5, reader.GetRandomWords(verbs).Count);

            string word = reader.GetRandomWords(verbs).First();

            Assert.IsType<string>(word);
        }
    }
}
