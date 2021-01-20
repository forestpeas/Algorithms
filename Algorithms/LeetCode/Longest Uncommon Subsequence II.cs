using System;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 522. Longest Uncommon Subsequence II
     * 
     * Given a list of strings, you need to find the longest uncommon subsequence among them.
     * The longest uncommon subsequence is defined as the longest subsequence of one of these
     * strings and this subsequence should not be any subsequence of the other strings.
     * 
     * The input will be a list of strings, and the output needs to be the length of the longest
     * uncommon subsequence. If the longest uncommon subsequence doesn't exist, return -1.
     * 
     * Example 1:
     * Input: "aba", "cdc", "eae"
     * Output: 3
     */
    public class Longest_Uncommon_Subsequence_II
    {
        public int FindLUSlength(string[] strs)
        {
            int res = -1;
            for (int i = 0; i < strs.Length; i++)
            {
                if (!strs.Where((s, j) => j != i && strs[i].IsSubsequenceOf(strs[j])).Any())
                {
                    res = Math.Max(res, strs[i].Length);
                }
            }
            return res;
        }
    }

    static class Extensions
    {
        public static bool IsSubsequenceOf(this string sub, string str)
        {
            if (sub.Length > str.Length) return false;

            int i = 0;
            foreach (char c in str)
            {
                if (sub[i] == c)
                {
                    if (++i == sub.Length) return true;
                }
            }

            return false;
        }
    }
}
