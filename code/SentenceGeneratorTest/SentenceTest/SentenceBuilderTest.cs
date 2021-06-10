using Sentence.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SentenceGeneratorTest.SentenceTest
{
    public class SentenceBuilderTest
    {
        private string wordsDummy = "{\"adjectives\": [ \"bombproof\" ], " +
                "\"adverbs\": [ \"astronomically\" ], \"nouns\": [ \"Platycerium\", \"mead\" ]," +
                "\"verbs\": [ \"develop\" ]}";
        [Fact]
        public void IsNotNull()
        {
            SentenceBuilder sb = new();
            Assert.NotNull(sb.StoreWords(wordsDummy));
        }

        [Fact]
        public void StoresKeys()
        {
            SentenceBuilder sb = new();
            Dictionary<string, List<string>> wordsDic = sb.StoreWords(wordsDummy);

            Assert.Equal(4, wordsDic.Keys.Count);
            Assert.Equal("adjectives", wordsDic.Keys.First().ToString());
            Assert.Equal("verbs", wordsDic.Keys.Last().ToString());
        }
    }
}