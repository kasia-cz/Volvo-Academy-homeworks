namespace homework3
{
    internal class Book
    {
        public string Title;
        public string Author;
        public List<string> Sentences;
        public Dictionary<string, int> Words;
        public List<string> Punctuation;

        public Book(string title, string author) // temporary constructor
        {
            Title = title;
            Author = author;
        }
    }
}
