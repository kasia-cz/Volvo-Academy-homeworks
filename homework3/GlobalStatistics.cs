namespace homework3
{
    internal static class GlobalStatistics
    {
        public static List<string> GlobalLongestSentencesByCharacters;
        public static List<string> GlobalShortestSentencesByWords;
        public static List<string> GlobalLongestWords;
        public static Dictionary<string, int> GlobalWords;
        public static Dictionary<char, int> GlobalLetters;
        public static Dictionary<char, int> GlobalPunctuation;

        public static void UpdateGlobalLongestSentencesByCharacters(List<string> sentences)
        {
            if (GlobalLongestSentencesByCharacters == null)
            {
                GlobalLongestSentencesByCharacters = new List<string>(sentences);
            }
            else
            {
                if (sentences.Any(s => s.Length > GlobalLongestSentencesByCharacters.Min(s => s.Length)))
                {
                    GlobalLongestSentencesByCharacters.AddRange(sentences);
                    GlobalLongestSentencesByCharacters.Sort((a, b) => b.Length.CompareTo(a.Length));
                    GlobalLongestSentencesByCharacters = GlobalLongestSentencesByCharacters.Take(10).ToList();
                }
            }
        }
    }
}

