using System;
using System.Collections.Generic;
using System.Linq;

namespace Capitalise
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = new Sentence("Let's go outside!");
            x[1].Capitalize = true;
            Console.WriteLine($"Your new string is {x}");
        }
    }

    public class Sentence
    {
        private string[] _wordList;
        private List<WordToken> _wordTokens;

        public Sentence(string plainText)
        {
            _wordList = plainText.Split(" ");
            _wordTokens = _wordList.Select(_ => new WordToken()).ToList();
        }

        public WordToken this[int index]
        {
            get => _wordTokens[index];
        }

        public override string ToString()
        {
            var newWordList = _wordTokens.Select((x, i) =>
            {
                return x.Capitalize ? _wordList[i].ToUpper() : _wordList[i];
            });
            return string.Join(" ", newWordList);
        }

        public class WordToken
        {
            public bool Capitalize;
        }
    }
}
