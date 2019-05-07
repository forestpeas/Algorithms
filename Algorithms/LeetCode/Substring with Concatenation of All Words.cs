using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 30. Substring with Concatenation of All Words
     * You are given a string, s, and a list of words, words, that are all of the same length. Find all starting indices of substring(s) in s that is a concatenation of each word in words exactly once and without any intervening characters.
     * 
     * Example 1:
     * 
     * Input:
     *   s = "barfoothefoobarman",
     *   words = ["foo","bar"]
     * Output: [0,9]
     * Explanation: Substrings starting at index 0 and 9 are "barfoor" and "foobar" respectively.
     * The output order does not matter, returning [9,0] is fine too.
     * 
     * Example 2:
     * 
     * Input:
     *   s = "wordgoodgoodgoodbestword",
     *   words = ["word","good","best","word"]
     * Output: []
     */
    public class SubstringWithConcatenationOfAllWords
    {
        // Your runtime beats 64.17 % of csharp submissions.
        // Your memory usage beats 69.23 % of csharp submissions.
        public IList<int> FindSubstring(string s, string[] words)
        {
            var result = new List<int>();
            if (words.Length < 1) return result;

            var wordCounts = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (wordCounts.TryGetValue(word, out int value))
                {
                    wordCounts[word] = ++value;
                }
                else
                {
                    wordCounts[word] = 1;
                }
            }

            int wordLength = words[0].Length;
            for (int i = 0; i < s.Length - wordLength * words.Length + 1; i++)
            {
                var knownWords = new Dictionary<string, int>(0);
                for (int j = 0; ; j++)
                {
                    if (j == words.Length)
                    {
                        result.Add(i);
                        break;
                    }

                    string currentWord = s.Substring(i + j * wordLength, wordLength);
                    if (wordCounts.TryGetValue(currentWord, out int count))
                    {
                        if (knownWords.TryGetValue(currentWord, out int currentCount))
                        {
                            if (++currentCount > count)
                            {
                                break;
                            }
                            knownWords[currentWord] = currentCount;
                        }
                        else
                        {
                            knownWords[currentWord] = 1;
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return result;
        }
    }
}
