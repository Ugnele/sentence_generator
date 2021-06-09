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
            string path = Directory.GetCurrentDirectory();
            string parentPath = Path.GetFullPath(Path.Combine(path, @"..\..\..\..\"));
            string resourcesPath = Path.GetFullPath(Path.Combine(parentPath, @"Words\resources\"));
            WordsController words = new();
            Assert.NotNull(words.ReadFile(resourcesPath, "verbs"));
            Assert.True(words.ReadFile(resourcesPath, "verbs").Contains("zoom"));
            Assert.Equal(words.ReadFile(resourcesPath, "verbs")[0], "Agenize");
        }
        
    }
}
