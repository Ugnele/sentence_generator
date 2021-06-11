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

            Assert.NotEmpty(wordsDic.Keys);
            Assert.Equal(4, wordsDic.Keys.Count);

            Assert.Equal("adjectives", wordsDic.Keys.First().ToString());
            Assert.Equal("adverbs", sb.StoreWords(wordsDummy).Keys.ElementAt(1));
            Assert.Equal("nouns", sb.StoreWords(wordsDummy).Keys.ElementAt(2));
            Assert.Equal("verbs", wordsDic.Keys.Last().ToString());
        }

        [Fact]
        public void StoresValues()
        {
            SentenceBuilder sb = new();
            Dictionary<string, List<string>> wordsDic = sb.StoreWords(wordsDummy);

            Assert.NotEmpty(wordsDic.Values);
            Assert.True(wordsDic.Values.Count <= 5);

            Assert.NotEmpty(wordsDic["adjectives"].ElementAt(0));
            Assert.NotEmpty(wordsDic["adverbs"].ElementAt(0));
            Assert.NotEmpty(wordsDic["nouns"].First());
            Assert.NotEmpty(wordsDic["nouns"].Last());
            Assert.NotEmpty(wordsDic["verbs"].ElementAt(0));
        }

        [Fact]
        public void BuildSentence()
        {
            SentenceBuilder sb = new();
            string sentence = sb.BuildSentence(wordsDummy, "1");

            Assert.NotEmpty(sentence);
            Assert.True(!sentence.Contains(" "));

            sentence = "";
            Assert.Empty(sentence);

            sentence = sb.BuildSentence(wordsDummy, "2");
            Assert.NotEmpty(sentence);
            Assert.Contains(" ", sentence);


            sentence = sb.BuildSentence(wordsDummy, "5");
            Assert.NotEmpty(sentence);
            Assert.Contains(" ", sentence);
            Assert.Contains(" and ", sentence);
        }

    }
}