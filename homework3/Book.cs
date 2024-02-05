namespace homework3
{
    internal class Book
    {
        public string Title;
        public string Author;
        public List<string> Sentences;
        public Dictionary<string, int> Words;
        public List<string> Punctuation;

        public Book(string title, string author, List<string> sentences) // temporary constructor
        {
            Title = title;
            Author = author;
            Sentences = sentences;
        }

        public List<string> Get10LongestSentencesByCharacters()
        {
            var longestSentencesByCharacters = Sentences
                .OrderByDescending(s => s.Length)
                .Take(10)
                .ToList();
            
            return longestSentencesByCharacters;
        }

        public List<string> Get10ShortestSentencesByWords()
        {
            var shortestSentencesByWords = Sentences
                .Where(s => s.Length >= 5)
                .OrderBy(s => s.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length)
                .Take(10)
                .ToList();
            
            return shortestSentencesByWords;
        }
    }
}
