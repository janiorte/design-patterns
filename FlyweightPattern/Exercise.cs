using System;
using System.Collections.Generic;
using System.Text;

namespace Coding.Exercise
{
    public class Sentence
    {
        private string PlainText { get; set; }
        private Dictionary<int, WordToken> WordTokens = new Dictionary<int, WordToken>();

        public Sentence(string plainText)
        {
            PlainText = plainText;
        }

        public WordToken this[int index]
        {
            get
            {
                if (!WordTokens.ContainsKey(index))
                {
                    WordTokens.Add(index, new WordToken { Capitalize = false });
                }

                return WordTokens[index];
            }
        }

        public override string ToString()
        {
            var words = PlainText.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            var sb = new StringBuilder();
            for(int i = 0; i < words.Length; i++)
            {
                if (WordTokens.ContainsKey(i) && WordTokens[i].Capitalize)
                {
                    sb.Append(words[i].ToUpper());
                }
                else
                {
                    sb.Append(words[i]);
                }
                if(i != words.Length - 1)
                {
                    sb.Append(" ");
                }
            }

            return sb.ToString();
        }

        public class WordToken
        {
            public bool Capitalize;
        }
    }
}
