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

        public static void UpdateGlobalShortestSentencesByWords(List<string> sentences)
        {
            if (GlobalShortestSentencesByWords == null)
            {
                GlobalShortestSentencesByWords = new List<string>(sentences);
            }
            else
            {
                if (sentences.Any(s => s.Split(' ').Length < GlobalShortestSentencesByWords.Max(s => s.Split(' ').Length)))
                {
                    GlobalShortestSentencesByWords.AddRange(sentences);
                    GlobalShortestSentencesByWords.Sort((a, b) => a.Split(' ').Length.CompareTo(b.Split(' ').Length));
                    GlobalShortestSentencesByWords = GlobalShortestSentencesByWords.Take(10).ToList();
                }
            }
        }

        internal static void UpdateGlobalLongestWords(List<string> words)
        {
            if (GlobalLongestWords == null)
            {
                GlobalLongestWords = new List<string>(words);
            }
            else
            {
                if (words.Any(w => w.Length > GlobalLongestWords.Min(w => w.Length)))
                {
                    GlobalLongestWords.AddRange(words);
                    GlobalLongestWords.Sort((a, b) => b.Length.CompareTo(a.Length));
                    GlobalLongestWords = GlobalLongestWords.Take(10).ToList();
                }
            }
        }
    }
}

