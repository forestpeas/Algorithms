using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 87. Scramble String
     * 
     * Given a string s1, we may represent it as a binary tree by partitioning it to two non-empty substrings recursively.
     * 
     * Below is one possible representation of s1 = "great":
     * 
     *     great
     *    /    \
     *   gr    eat
     *  / \    /  \
     * g   r  e   at
     *            / \
     *           a   t
     * To scramble the string, we may choose any non-leaf node and swap its two children.
     * 
     * For example, if we choose the node "gr" and swap its two children, it produces a scrambled string "rgeat".
     * 
     *     rgeat
     *    /    \
     *   rg    eat
     *  / \    /  \
     * r   g  e   at
     *            / \
     *           a   t
     * We say that "rgeat" is a scrambled string of "great".
     * 
     * Similarly, if we continue to swap the children of nodes "eat" and "at", it produces a scrambled string "rgtae".
     * 
     *     rgtae
     *    /    \
     *   rg    tae
     *  / \    /  \
     * r   g  ta  e
     *        / \
     *       t   a
     * We say that "rgtae" is a scrambled string of "great".
     * 
     * Given two strings s1 and s2 of the same length, determine if s2 is a scrambled string of s1.
     * 
     * Example 1:
     * 
     * Input: s1 = "great", s2 = "rgeat"
     * Output: true
     * Example 2:
     * 
     * Input: s1 = "abcde", s2 = "caebd"
     * Output: false
     */
    public class ScrambleString
    {
        public bool IsScramble(string s1, string s2)
        {
            // Assume s2 is at least an anagram of s1.
            if (s1 == s2) return true;
            var CharCounts1 = new Dictionary<char, int>();
            for (int i = 0; i < s1.Length - 1; i++)
            {
                if (CharCounts1.TryGetValue(s1[i], out int count1))
                {
                    CharCounts1[s1[i]] = count1 + 1;
                }
                else
                {
                    CharCounts1.Add(s1[i], 1);
                }
                var CharCounts2 = new Dictionary<char, int>();
                int j = 0;
                for (; j <= i; j++)
                {
                    if (CharCounts1.TryGetValue(s2[j], out count1))
                    {
                        if (CharCounts2.TryGetValue(s2[j], out int count2))
                        {
                            count2++;
                        }
                        else
                        {
                            count2 = 1;
                        }
                        if (count2 > count1) break;
                        CharCounts2[s2[j]] = count2;
                    }
                    else break;
                }
                if (j == i + 1 && CharCounts1.Count == CharCounts2.Count
                    && IsScramble(s1.Substring(0, i + 1), s2.Substring(0, i + 1))
                    && IsScramble(s1.Substring(i + 1), s2.Substring(i + 1))) return true;
                CharCounts2.Clear();
                for (j = s1.Length - i - 1; j < s1.Length; j++)
                {
                    if (CharCounts1.TryGetValue(s2[j], out count1))
                    {
                        if (CharCounts2.TryGetValue(s2[j], out int count2))
                        {
                            count2++;
                        }
                        else
                        {
                            count2 = 1;
                        }
                        if (count2 > count1) break;
                        CharCounts2[s2[j]] = count2;
                    }
                    else break;
                }
                if (j == s1.Length && CharCounts1.Count == CharCounts2.Count
                    && IsScramble(s1.Substring(0, i + 1), s2.Substring(s1.Length - i - 1))
                    && IsScramble(s1.Substring(i + 1), s2.Substring(0, s1.Length - i - 1))) return true;
            }
            return false;
        }
    }
}
