namespace homework3
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("File processing started.");
            string sourcePath = "Books";
            string currentDirectoryPath = Directory.GetCurrentDirectory();
            string resultsDirectoryPath = Path.GetFullPath(Path.Combine(currentDirectoryPath, @"..\..\..\", "Results"));

            string[] filePaths = Directory.GetFiles(sourcePath, "*.txt");

            var tasks = new List<Task>();

            var processedFiles = 0;
            var numberOfFiles = filePaths.Length;

            await Task.WhenAll(filePaths.Select(async filePath =>
            {
                Book book = await TextProcessor.ReadAsync(filePath);
                await ResultsWriter.WriteResultsAsync(book, resultsDirectoryPath);
                Console.WriteLine($"Files processed: {Interlocked.Increment(ref processedFiles)}/{numberOfFiles}");
            }));

            Task.WhenAll(tasks).Wait();

            await ResultsWriter.WriteGlobalStatisticsAsync(resultsDirectoryPath);
            Console.WriteLine("File processing successfully completed.");
        }
    }
}
