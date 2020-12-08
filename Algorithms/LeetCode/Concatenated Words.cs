using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 472. Concatenated Words
     * 
     * Given a list of words (without duplicates), please write a program that returns all concatenated
     * words in the given list of words.
     * A concatenated word is defined as a string that is comprised entirely of at least two shorter
     * words in the given array.
     * 
     * Example:
     * Input: ["cat","cats","catsdogcats","dog","dogcatsdog","hippopotamuses","rat","ratcatdogcat"]
     * 
     * Output: ["catsdogcats","dogcatsdog","ratcatdogcat"]
     * 
     * Explanation: "catsdogcats" can be concatenated by "cats", "dog" and "cats"; 
     *  "dogcatsdog" can be concatenated by "dog", "cats" and "dog"; 
     * "ratcatdogcat" can be concatenated by "rat", "cat", "dog" and "cat".
     */
    public class Concatenated_Words
    {
        public IList<string> FindAllConcatenatedWordsInADict(string[] words)
        {
            var res = new List<string>();
            var wordDict = new HashSet<string>();
            foreach (var word in words.OrderBy(w => w.Length))
            {
                if (CanBreak(word, wordDict))
                {
                    res.Add(word);
                }
                wordDict.Add(word);
            }
            return res;
        }

        private bool CanBreak(string s, HashSet<string> wordDict)
        {
            // copied from "139. Word Break"
            if (s.Length == 0) return false;
            bool[] mem = new bool[s.Length + 1];
            mem[0] = true;
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (mem[j] && wordDict.Contains(s.Substring(j, i - j + 1)))
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
