using System.Text.RegularExpressions;

namespace homework3
{
    internal class TextProcessor
    {
        public static async Task<Book> ReadAsync(string filePath)
        {
            Console.WriteLine("Read");
            string[] lines = await File.ReadAllLinesAsync(filePath);
            string title = GetBookTitle(lines);
            string author = GetBookAuthor(lines);

            var bookText = await File.ReadAllTextAsync(filePath);

            var startLineLenght = "***START OF THE PROJECT GUTENBERG EBOOK  ***".Length;
            var titleLenght = title.Length;

            Match startLine = Regex.Match(bookText, @"^.*\*\*\* START.*$", RegexOptions.Multiline);
            bookText = bookText.Substring(startLine.Index + startLineLenght + titleLenght + 1);

            Match endLine = Regex.Match(bookText, @"^.*\*\*\* END.*$", RegexOptions.Multiline);
            bookText = bookText.Substring(0, endLine.Index);

            var sentences = GetListOfSentences(bookText);

            var words = GetDictOfWords(bookText);

            var (letters, punctuation) = GetLettersAndPunctuation(bookText);

            return new Book(title, author, sentences, words, letters, punctuation);
        }

        public static async Task WriteResultsAsync(Book book, string resultsDirectoryPath)
        {
            Console.WriteLine("Write");
            string fileName = Regex.Replace(book.Title, @"[:;,.!]", "");
            string newFilePath = Path.Combine(resultsDirectoryPath, $"{fileName}.txt");

            if (!File.Exists(newFilePath))
            {
                List<string> newLines = new List<string>();
                newLines.Add($"Title: {book.Title}");
                newLines.Add($"Author: {book.Author}");

                newLines.Add("\n10 longest sentences by number of characters:");
                var longestSentences = book.Get10LongestSentencesByCharacters();
                foreach (var longSentence in longestSentences)
                {
                    newLines.Add($"\n{longSentence} - number of characters: {longSentence.Length}");
                }

                newLines.Add("\n10 shortest sentences by numbers of words:");
                var shortestSentences = book.Get10ShortestSentencesByWords();
                foreach (var shortSentence in shortestSentences)
                {
                    newLines.Add($"{shortSentence} - number of words: {shortSentence.Split(' ').Length}");
                }

                newLines.Add("\n10 most common words:");
                var mostCommonWords = book.Get10MostCommonWords();
                foreach (var pair in mostCommonWords)
                {
                    newLines.Add($"Word \"{pair.Key}\", count: {pair.Value}");
                }

                newLines.Add("\n10 most common letters:");
                var mostCommonLetters = book.Get10MostCommonLetters();
                foreach (var pair in mostCommonLetters)
                {
                    newLines.Add($"Letter \"{pair.Key}\", count: {pair.Value}");
                }

                newLines.Add("\n10 most popular punctuation marks:");
                var mostCommonPunctuation = book.Get10MostCommonPunctuationMarks();
                foreach (var pair in mostCommonPunctuation)
                {
                    newLines.Add($"Punctuation mark \"{pair.Key}\", count: {pair.Value}");
                }

                await File.WriteAllLinesAsync(newFilePath, newLines);
            }
        }

        private static string GetBookTitle(string[] lines)
        {
            string titleLineStart = "Title: ";
            return GetLineAfterSentence(lines, titleLineStart);
        }

        private static string GetBookAuthor(string[] lines)
        {
            string authorLineStart = "Author: ";
            return GetLineAfterSentence(lines, authorLineStart);
        }

        private static string GetLineAfterSentence(string[] lines, string sentence)
        {
            foreach (string line in lines)
            {
                if (line.StartsWith(sentence))
                {
                    return line.Substring(sentence.Length).Trim();
                }
            }
            return string.Empty;
        }
        private static List<string> GetListOfSentences(string text)
        {
            char[] unwantedChars = ['“', '”', '‘', '’', '"', '\''];
            string pattern = "[" + Regex.Escape(new string(unwantedChars)) + "]";
            text = Regex.Replace(text, pattern, string.Empty);

            List<string> sentences = Regex.Split(text, @"(?<=[\.!\?])\s+").ToList();

            return sentences;
        }

        private static Dictionary<string, int> GetDictOfWords(string text)
        {
            string[] words = Regex.Split(text, @"\W+");
            words = words.Where(word => !string.IsNullOrWhiteSpace(word)).ToArray();

            Dictionary<string, int> wordCount = new Dictionary<string, int>();
            foreach (string word in words)
            {
                if (wordCount.ContainsKey(word))
                {
                    wordCount[word]++;
                }
                else
                {
                    wordCount.Add(word, 1);
                }
            }
            return wordCount;
        }

        private static (Dictionary<char, int>, Dictionary<char, int>) GetLettersAndPunctuation(string text)
        {
            Dictionary<char, int> punctuation = new Dictionary<char, int>();
            Dictionary<char, int> letters = new Dictionary<char, int>();

            foreach (char c in text)
            {
                if (char.IsPunctuation(c))
                {
                    if (punctuation.ContainsKey(c))
                    {
                        punctuation[c]++;
                    }
                    else
                    {
                        punctuation.Add(c, 1);
                    }
                    continue;
                }

                if (char.IsLetter(c))
                {
                    if (letters.ContainsKey(c))
                    {
                        letters[c]++;
                    }
                    else
                    {
                        letters.Add(c, 1);
                    }
                }
            }
            return (letters, punctuation);
        }
    }
}
