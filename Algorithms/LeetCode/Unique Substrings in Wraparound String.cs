using System;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 467. Unique Substrings in Wraparound String
     * 
     * Consider the string s to be the infinite wraparound string of "abcdefghijklmnopqrstuvwxyz",
     * so s will look like this: "...zabcdefghijklmnopqrstuvwxyzabcdefghijklmnopqrstuvwxyzabcd....".
     * 
     * Now we have another string p. Your job is to find out how many unique non-empty substrings of
     * p are present in s. In particular, your input is the string p and you need to output the number
     * of different non-empty substrings of p in the string s.
     * 
     * Note: p consists of only lowercase English letters and the size of p might be over 10000.
     * 
     * Example 1:
     * Input: "a"
     * Output: 1
     * 
     * Explanation: Only the substring "a" of string "a" is in the string s.
     * 
     * Example 2:
     * Input: "cac"
     * Output: 2
     * Explanation: There are two substrings "a", "c" of string "cac" in the string s.
     * 
     * Example 3:
     * Input: "zab"
     * Output: 6
     * Explanation: There are six substrings "z", "a", "b", "za", "ab", "zab" of string "zab" in the string s.
     */
    public class Unique_Substrings_in_Wraparound_String
    {
        public int FindSubstringInWraproundString(string p)
        {
            // O(n), seen[c] is the maximum length of continuous substring that ends with c.
            int[] seen = new int[128];
            int count = 0;
            char prev = '#';
            foreach (char c in p)
            {
                char prevInAlphabet = c == 'a' ? 'z' : (char)(c - 1);
                count = prev == prevInAlphabet ? count + 1 : 1;
                seen[c] = Math.Max(seen[c], count);
                prev = c;
            }
            return seen.Sum();
        }

        public int FindSubstringInWraproundString2(string p)
        {
            // O(n^2), seen[c] is maximum length of continuous substring that starts with c,
            // for example, "abcabcd" -> seen['a'] = 4, seen['b'] = 3, seen['c'] = 2, seen['d'] = 1.
            int[] seen = new int[26];
            int res = 0, start = 0, count = 0;
            char prev = '#';
            foreach (char c in p)
            {
                char prevInAlphabet = c == 'a' ? 'z' : (char)(c - 1);
                if (prev == prevInAlphabet)
                {
                    count++;
                }
                else
                {
                    start = c - 'a';
                    count = 1;
                }
                for (int i = 0; i < count; i++)
                {
                    if (seen[(start + i) % 26] < count - i)
                    {
                        seen[(start + i) % 26] = count - i;
                        res++;
                    }
                }
                prev = c;
            }
            return res;
        }
    }
}
