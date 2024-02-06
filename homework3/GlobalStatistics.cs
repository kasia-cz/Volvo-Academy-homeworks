namespace homework3
{
    internal static class GlobalStatistics
    {
        public static List<string> GlobalLongestSentencesByCharacters;
        public static List<string> GlobalShortestSentencesByWords;
        public static List<string> GlobalLongestWords;
        public static Dictionary<string, int> GlobalWords;
        public static Dictionary<char, int> GlobalLetters;

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

        public static void UpdateGlobalLongestWords(List<string> words)
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

        public static void UpdateGlobalDictOfWords(Dictionary<string, int> wordsDict)
        {
            if (GlobalWords == null)
            {
                GlobalWords = new Dictionary<string, int>();
            }
            UpdateGlobalDict(GlobalWords, wordsDict);
        }

        public static void UpdateGlobalDictOfLetters(Dictionary<char, int> lettersDict)
        {
            if (GlobalLetters == null)
            {
                GlobalLetters = new Dictionary<char, int>();
            }
            UpdateGlobalDict(GlobalLetters, lettersDict);
        }

        private static void UpdateGlobalDict<T>(Dictionary<T, int> globalDict, Dictionary<T, int> dict)
        {
            foreach (var pair in dict)
            {
                if (globalDict.ContainsKey(pair.Key))
                {
                    globalDict[pair.Key] += pair.Value;
                }
                else
                {
                    globalDict.Add(pair.Key, pair.Value);
                }
            }
        }
        public static List<KeyValuePair<string, int>> GetGlobal10MostCommonWords()
        {
            return GlobalWords.OrderByDescending(pair => pair.Value).Take(10).ToList();
        }

        public static List<KeyValuePair<char, int>> GetGlobal10MostCommonLetters()
        {
            return GlobalLetters.OrderByDescending(pair => pair.Value).Take(10).ToList();
        }
    }
}

