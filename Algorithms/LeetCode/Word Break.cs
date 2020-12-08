using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 139. Word Break
     * 
     * Given a non-empty string s and a dictionary wordDict containing a list of non-empty words,
     * determine if s can be segmented into a space-separated sequence of one or more dictionary words.
     * 
     * Note:
     * 
     * The same word in the dictionary may be reused multiple times in the segmentation.
     * You may assume the dictionary does not contain duplicate words.
     * 
     * Example 1:
     * 
     * Input: s = "leetcode", wordDict = ["leet", "code"]
     * Output: true
     * Explanation: Return true because "leetcode" can be segmented as "leet code".
     * 
     * Example 2:
     * 
     * Input: s = "applepenapple", wordDict = ["apple", "pen"]
     * Output: true
     * Explanation: Return true because "applepenapple" can be segmented as "apple pen apple".
     *              Note that you are allowed to reuse a dictionary word.
     * 
     * Example 3:
     * 
     * Input: s = "catsandog", wordDict = ["cats", "dog", "sand", "and", "cat"]
     * Output: false
     */
    public class WordBreakSolution
    {
        // Recursive solution with memoization.
        public bool WordBreak(string s, IList<string> wordDict)
        {
            return WordBreak(s, wordDict, new Dictionary<string, bool>());
        }

        private bool WordBreak(string s, IList<string> wordDict, Dictionary<string, bool> mem)
        {
            if (mem.TryGetValue(s, out var value)) return value;
            foreach (string word in wordDict)
            {
                if (s.StartsWith(word))
                {
                    string nextSubString = s.Substring(word.Length);
                    if (nextSubString.Length == 0 || WordBreak(nextSubString, wordDict, mem))
                    {
                        mem.Add(s, true);
                        return true;
                    }
                }
            }
            mem.Add(s, false);
            return false;
        }

        public bool WordBreakDP(string s, IList<string> wordDict)
        {
            // mem[i + 1] means s[0...i] can be segmented.
            var words = new HashSet<string>(wordDict);
            bool[] mem = new bool[s.Length + 1];
            mem[0] = true;

            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    // j separates s[0...i] into left and right parts.
                    // For example: leet
                    //               ↑ ↑
                    //               j i
                    // mem[j] = "l", s.Substring(j, i - j + 1) = "eet"
                    // If they are both "true", then the whole "leet" is also "true".
                    if (mem[j] && words.Contains(s.Substring(j, i - j + 1)))
                    {
                        mem[i + 1] = true;
                        break;
                    }
                }
            }

            return mem[mem.Length - 1];
        }
    }
}
