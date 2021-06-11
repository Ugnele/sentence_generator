using Sentence.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SentenceGeneratorTest.SentenceTest
{
    public class SentenceControllerTest
    {
        [Fact]
        public void IsSentenceBuilt()
        {
            SentenceController sentence = new();
            Assert.NotNull(sentence.GetSentence());
        }
    }
}
