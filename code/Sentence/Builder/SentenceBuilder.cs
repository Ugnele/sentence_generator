using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sentence.Builder
{
    public class SentenceBuilder
    {
        public Dictionary<string, List<string>> StoreWords(string words)
        {
            char[] c = words.ToCharArray();
            string key = "";
            Dictionary<string, List<string>> wordsDic = new();
            List<string> nounList = new();

            string word = "";
            int cIndex = 0;
            while (cIndex < c.Length)
            {
                //do until a letter is hit
                while (cIndex < c.Length && !Char.IsLetter(c[cIndex])) cIndex++;
                //construct a word
                while (cIndex < c.Length && Char.IsLetter(c[cIndex]))
                {
                    word += c[cIndex];
                    cIndex++;
                }
                if (word.Equals("adjectives") || word.Equals("adverbs") ||
                        word.Equals("nouns") || word.Equals("verbs"))
                {
                    key = word;
                } else if (!word.Equals(""))
                {
                    if (key.Equals("nouns"))
                    {
                        nounList.Add(word);
                        if (nounList.Count > 1) wordsDic.Add(key, nounList);
                    }
                    else wordsDic.Add(key, word.Split().ToList<string>());
                }
                word = "";
            }
            return wordsDic;
        }

        public string BuildSentence(string strWords, string sentenceLength)
        {
            Dictionary<string, List<string>> words = StoreWords(strWords);
            Random random = new();
            int randomIndex = 0;
            if (sentenceLength.Equals("5")) randomIndex = random.Next(0, 2);

            string sentence = "";
            switch (sentenceLength)
            {
                case "1":
                    sentence = words["nouns"].ElementAt(randomIndex);
                    break;
                case "2":
                    sentence = words["adjectives"].First() + " " +
                        words["nouns"].ElementAt(randomIndex); ;
                    break;
                case "3":
                    sentence = words["adverbs"].First() + " " +
                         words["adjectives"].First() + " " +
                         words["nouns"].ElementAt(randomIndex); ;
                    break;
                case "4":
                    sentence = words["verbs"].First() + " " +
                         words["adverbs"].First() + " " +
                         words["adjectives"].First() + " " +
                         words["nouns"].ElementAt(randomIndex); ;
                    break;
                case "5":
                    sentence = words["verbs"].First() + " " +
                         words["adverbs"].First() + " " +
                         words["adjectives"].First() + " " +
                         words["nouns"].First() + " " +
                         " and " + words["nouns"].ElementAt(1);
                    break;
            }
            return sentence;
        }
    }
}
