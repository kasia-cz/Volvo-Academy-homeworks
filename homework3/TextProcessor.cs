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

            return new Book(title, author);
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
    }
}
