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
            List<string> wordList = new();

            string word = "";
            int cIndex = 0;
            while (cIndex < c.Length)
            {
                if (Char.IsLetter(c[cIndex]) && c[cIndex] != ' ')
                {
                    word += c[cIndex];
                } else
                {
                    while ((cIndex + 1) < c.Length 
                        && !Char.IsLetter(c[cIndex + 1])) cIndex++;

                    if (word.Equals("adjectives") || word.Equals("adverbs") ||
                        word.Equals("nouns") || word.Equals("verbs"))
                    {
                        key = word;
                    } else
                    {
                        if(wordList.Count > 1)
                        {
                            wordsDic.Add("nouns", wordList);
                            wordList.Clear();
                        }
                        wordList.Add(word);
                        if (!key.Equals("nouns") && !key.Equals(""))
                        {
                            wordsDic.Add(key, wordList);
                            wordList.Clear();
                        }
                    }
                    word = "";
                }
                cIndex++;
            }
            return wordsDic;
        }

        
     }
}
