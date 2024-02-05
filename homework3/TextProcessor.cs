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

            return new Book(title, author, sentences);
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
                    newLines.Add($"\n{shortSentence} - number of words: {shortSentence.Split(' ').Length}");
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
    }
}
