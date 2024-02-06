using System.Text.RegularExpressions;

namespace homework3
{
    internal class ResultsWriter
    {
        public static async Task WriteResultsAsync(Book book, string resultsDirectoryPath)
        {
            var fileName = Regex.Replace(book.Title, @"[:;,.!]", "");
            var newFilePath = Path.Combine(resultsDirectoryPath, $"{fileName}.txt");

            if (!File.Exists(newFilePath))
            {
                var newLines = new List<string>();
                newLines.Add($"Title: {book.Title}");
                newLines.Add($"Author: {book.Author}");

                newLines.Add("\n10 longest sentences by number of characters:");
                var longestSentences = book.Get10LongestSentencesByCharacters();
                foreach (var longSentence in longestSentences)
                {
                    newLines.Add($"\n{longSentence} - number of characters: {longSentence.Length}");
                }
                GlobalStatistics.UpdateGlobalLongestSentencesByCharacters(longestSentences);

                newLines.Add("\n10 shortest sentences by numbers of words:");
                var shortestSentences = book.Get10ShortestSentencesByWords();
                foreach (var shortSentence in shortestSentences)
                {
                    newLines.Add($"{shortSentence} - number of words: {shortSentence.Split(' ').Length}");
                }
                GlobalStatistics.UpdateGlobalShortestSentencesByWords(shortestSentences);

                newLines.Add("\n10 longest words:");
                var longestWords = book.Get10LongestWords();
                foreach (var longWord in longestWords)
                {
                    newLines.Add($"Word \"{longWord}\", length: {longWord.Length}");
                }
                GlobalStatistics.UpdateGlobalLongestWords(longestWords);

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

        public static async Task WriteGlobalStatisticsAsync(string resultsDirectoryPath)
        {
            var newFilePath = Path.Combine(resultsDirectoryPath, $"Global Statistics.txt");

            if (!File.Exists(newFilePath))
            {
                var newLines = new List<string>();

                newLines.Add("Global 10 longest sentences by number of characters:");
                foreach (var sentence in GlobalStatistics.GlobalLongestSentencesByCharacters)
                {
                    newLines.Add($"\n{sentence} - number of characters: {sentence.Length}");
                }

                newLines.Add("\nGlobal 10 shortest sentences by numbers of words:");
                foreach (var sentence in GlobalStatistics.GlobalShortestSentencesByWords)
                {
                    newLines.Add($"{sentence} - number of words: {sentence.Split(' ').Length}");
                }

                newLines.Add("\nGlobal 10 longest words:");
                foreach (var word in GlobalStatistics.GlobalLongestWords)
                {
                    newLines.Add($"Word \"{word}\", length: {word.Length}");
                }

                await File.WriteAllLinesAsync(newFilePath, newLines);
            }
        }
    }
}
