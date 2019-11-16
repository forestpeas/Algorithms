using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 392. Is Subsequence
     * 
     * Given a string s and a string t, check if s is subsequence of t.
     * 
     * You may assume that there is only lower case English letters in both s and t. t is potentially
     * a very long (length ~= 500,000) string, and s is a short string (<=100).
     * 
     * A subsequence of a string is a new string which is formed from the original string by deleting
     * some (can be none) of the characters without disturbing the relative positions of the remaining
     * characters. (ie, "ace" is a subsequence of "abcde" while "aec" is not).
     * 
     * Example 1:
     * s = "abc", t = "ahbgdc"
     * 
     * Return true.
     * 
     * Example 2:
     * s = "axc", t = "ahbgdc"
     * 
     * Return false.
     * 
     * Follow up:
     * If there are lots of incoming S, say S1, S2, ... , Sk where k >= 1B, and you want to check one by
     * one to see if T has its subsequence. In this scenario, how would you change your code?
     */
    public class Is_Subsequence
    {
        public bool IsSubsequence(string s, string t)
        {
            if (s.Length == 0) return true;

            int i = 0;
            foreach (char c in t)
            {
                if (s[i] == c)
                {
                    if (++i == s.Length) return true;
                }
            }

            return false;
        }

        public bool IsSubsequence2(string s, string t)
        {
            // Follow up question.
            // Pre-process t in initialization stage.
            List<int>[] map = new List<int>[256];
            for (int i = 0; i < t.Length; i++)
            {
                if (map[t[i]] == null) map[t[i]] = new List<int>();
                map[t[i]].Add(i);
            }

            // Process each s.
            int idx = 0;
            foreach (char c in s)
            {
                if (map[c] == null) return false;
                int pos = map[c].BinarySearch(idx);
                if (pos < 0) pos = ~pos;
                if (pos == map[c].Count) return false;
                idx = map[c][pos] + 1;
            }

            return true;
        }
    }
}
