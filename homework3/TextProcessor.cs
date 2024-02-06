using System.Text.RegularExpressions;

namespace homework3
{
    internal class TextProcessor
    {
        private static readonly object lockObjectWords = new object();
        private static readonly object lockObjectLetters = new object();
        public static async Task<Book> ReadAsync(string filePath)
        {
            var lines = await File.ReadAllLinesAsync(filePath);
            var title = FindBookTitle(lines);
            var author = FindBookAuthor(lines);

            Console.WriteLine($"Started processing of \"{title}\" by {author} ({filePath})");

            var bookText = await File.ReadAllTextAsync(filePath);

            var startLineLenght = "***START OF THE PROJECT GUTENBERG EBOOK  ***".Length;
            var titleLenght = title.Length;

            Match startLine = Regex.Match(bookText, @"^.*\*\*\* START.*$", RegexOptions.Multiline);
            bookText = bookText.Substring(startLine.Index + startLineLenght + titleLenght + 1);

            Match endLine = Regex.Match(bookText, @"^.*\*\*\* END.*$", RegexOptions.Multiline);
            bookText = bookText.Substring(0, endLine.Index);

            var sentences = GetListOfSentences(bookText);

            var words = GetDictOfWords(bookText);

            var (letters, punctuation) = GetLettersDictAndPunctuationDict(bookText);

            return new Book(title, author, sentences, words, letters, punctuation);
        }

        private static string FindBookTitle(string[] lines)
        {
            var titleLineStartPhrase = "Title: ";
            return GetLineAfterPhrase(lines, titleLineStartPhrase);
        }

        private static string FindBookAuthor(string[] lines)
        {
            var authorLineStartPhrase = "Author: ";
            return GetLineAfterPhrase(lines, authorLineStartPhrase);
        }

        private static string GetLineAfterPhrase(string[] lines, string phrase)
        {
            foreach (string line in lines)
            {
                if (line.StartsWith(phrase))
                {
                    return line.Substring(phrase.Length).Trim();
                }
            }
            return string.Empty;
        }
        private static List<string> GetListOfSentences(string text)
        {
            char[] unwantedChars = ['“', '”', '‘', '’', '"', '\''];
            var pattern = "[" + Regex.Escape(new string(unwantedChars)) + "]";
            text = Regex.Replace(text, pattern, string.Empty);

            var sentences = Regex.Split(text, @"(?<=[\.!\?])\s+").ToList();

            return sentences;
        }

        private static Dictionary<string, int> GetDictOfWords(string text)
        {
            var words = Regex.Split(text, @"\W+");
            words = words.Where(word => !string.IsNullOrWhiteSpace(word)).ToArray();

            var wordsDict = new Dictionary<string, int>();
            foreach (string word in words)
            {
                CountItemToDictionary(wordsDict, word);
            }
            lock (lockObjectWords)
            {
                GlobalStatistics.UpdateGlobalDictOfWords(wordsDict);
            }
            return wordsDict;
        }

        private static (Dictionary<char, int>, Dictionary<char, int>) GetLettersDictAndPunctuationDict(string text)
        {
            var punctuationDict = new Dictionary<char, int>();
            var lettersDict = new Dictionary<char, int>();

            foreach (char c in text)
            {
                if (char.IsLetter(c))
                {
                    CountItemToDictionary(lettersDict, char.ToLower(c));
                    continue;
                }

                if (char.IsPunctuation(c))
                {
                    CountItemToDictionary(punctuationDict, c);
                }
            }
            lock (lockObjectLetters)
            {
                GlobalStatistics.UpdateGlobalDictOfLetters(lettersDict);
            }
            return (lettersDict, punctuationDict);
        }

        private static void CountItemToDictionary<T>(Dictionary<T, int> dictionary, T item)
        {
            if (dictionary.ContainsKey(item))
            {
                dictionary[item]++;
            }
            else
            {
                dictionary.Add(item, 1);
            }
        }
    }
}
