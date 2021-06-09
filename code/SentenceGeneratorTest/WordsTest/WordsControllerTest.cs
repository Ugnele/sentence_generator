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

        /// Checks if 
        /*[Fact]
        public void ReadFileTest()
        {
            WordsController words = new();
            Assert.NotNull(words.ReadFile("verbs"));
        }
        */
    }
}
