using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 140. Word Break II
     * 
     * Given a non-empty string s and a dictionary wordDict containing a list of non-empty words,
     * add spaces in s to construct a sentence where each word is a valid dictionary word. Return
     * all such possible sentences.
     * 
     * Note:
     * 
     * The same word in the dictionary may be reused multiple times in the segmentation.
     * You may assume the dictionary does not contain duplicate words.
     * Example 1:
     * 
     * Input:
     * s = "catsanddog"
     * wordDict = ["cat", "cats", "and", "sand", "dog"]
     * Output:
     * [
     *   "cats and dog",
     *   "cat sand dog"
     * ]
     * 
     * Example 2:
     * 
     * Input:
     * s = "pineapplepenapple"
     * wordDict = ["apple", "pen", "applepen", "pine", "pineapple"]
     * Output:
     * [
     *   "pine apple pen apple",
     *   "pineapple pen apple",
     *   "pine applepen apple"
     * ]
     * Explanation: Note that you are allowed to reuse a dictionary word.
     * 
     * Example 3:
     * 
     * Input:
     * s = "catsandog"
     * wordDict = ["cats", "dog", "sand", "and", "cat"]
     * Output:
     * []
     */
    public class WordBreakII
    {
        // Recursive solution with memoization.
        public IList<string> WordBreak(string s, IList<string> wordDict)
        {
            return WordBreak(s, wordDict, new Dictionary<string, List<string>>());
        }

        private IList<string> WordBreak(string s, IList<string> wordDict, Dictionary<string, List<string>> mem)
        {
            if (mem.TryGetValue(s, out var value)) return value;
            var results = new List<string>();
            foreach (string word in wordDict)
            {
                if (s.StartsWith(word))
                {
                    string nextSubString = s.Substring(word.Length);
                    if (nextSubString.Length == 0)
                    {
                        results.Add(word);
                    }
                    else
                    {
                        foreach (string right in WordBreak(nextSubString, wordDict, mem))
                        {
                            results.Add(word + $" {right}");
                        }
                    }
                }
            }
            mem.Add(s, results);
            return results;
        }

        // DP solution derived from "Problem 139. Word Break", gets Memory Limit Exceeded exception.
        // How is this solution different from the one above? Maybe it's because this solution searches
        // for all possible results for all possible substrings, for example, we've found the results of
        // s[0...s.Length - 2], but when it comes to s[s.Length - 1], there is not any results, so the
        // effort was wasted. But the solution above only searches for those that might be the final result,
        // because it first checks for a necessary condition: there must exist a word in wordDict that "s"
        // starts with.
        public IList<string> WordBreakDP(string s, IList<string> wordDict)
        {
            var words = new HashSet<string>(wordDict);
            List<string>[] mem = new List<string>[s.Length + 1];
            mem[0] = new List<string>() { string.Empty };

            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    string rightSubStr = s.Substring(j, i - j + 1);
                    if (mem[j] != null && words.Contains(rightSubStr))
                    {
                        if (mem[i + 1] == null) mem[i + 1] = new List<string>();
                        if (i != s.Length - 1) rightSubStr = rightSubStr + " ";
                        mem[i + 1].AddRange(mem[j].Select(left => left + rightSubStr));
                    }
                }
            }

            return mem[mem.Length - 1] ?? new List<string>();
        }
    }
}
