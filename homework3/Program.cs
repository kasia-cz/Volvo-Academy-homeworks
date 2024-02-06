namespace homework3
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string sourcePath = "Books";
            string currentDirectoryPath = Directory.GetCurrentDirectory();
            string resultsDirectoryPath = Path.GetFullPath(Path.Combine(currentDirectoryPath, @"..\..\..\", "Results"));

            string[] filePaths = Directory.GetFiles(sourcePath, "*.txt");

            var tasks = new List<Task>();

            Parallel.ForEach(filePaths, filePath =>
            {
                var task = Task.Run(async () =>
                {
                    Book book = await TextProcessor.ReadAsync(filePath);
                    await ResultsWriter.WriteResultsAsync(book, resultsDirectoryPath);
                });

                tasks.Add(task);
            });

            Task.WhenAll(tasks).Wait();

            await ResultsWriter.WriteGlobalStatisticsAsync(resultsDirectoryPath);
        }
    }
}
