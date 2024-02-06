namespace homework3
{
    internal class Book
    {
        public string Title;
        public string Author;
        public List<string> Sentences;
        public Dictionary<string, int> Words;
        public Dictionary<char, int> Letters;
        public Dictionary<char, int> Punctuation;

        public Book(string title, string author, List<string> sentences, Dictionary<string, int> words, Dictionary<char, int> letters, Dictionary<char, int> punctuation)
        {
            Title = title;
            Author = author;
            Sentences = sentences;
            Words = words;
            Letters = letters;
            Punctuation = punctuation;
        }

        public List<string> Get10LongestSentencesByCharacters()
        {
            return Sentences.OrderByDescending(s => s.Length).Take(10).ToList();
        }

        public List<string> Get10ShortestSentencesByWords()
        {
            return Sentences.Where(s => s.Length >= 5)
                .OrderBy(s => s.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length)
                .Take(10)
                .ToList();
        }

        public List<string> Get10LongestWords()
        {
            return Words.OrderByDescending(pair => pair.Key.Length)
                .Select(pair => pair.Key)
                .Take(10)
                .ToList();
        }

        public List<KeyValuePair<string, int>> Get10MostCommonWords()
        {
            return Words.OrderByDescending(pair => pair.Value).Take(10).ToList();
        }

        public List<KeyValuePair<char, int>> Get10MostCommonLetters()
        {
            return Letters.OrderByDescending(pair => pair.Value).Take(10).ToList();
        }

        public List<KeyValuePair<char, int>> Get10MostCommonPunctuationMarks()
        {
            return Punctuation.OrderByDescending(pair => pair.Value).Take(10).ToList();
        }
    }
}
