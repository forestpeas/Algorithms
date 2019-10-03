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
            // We need to find a "splitting line" in s1 and s2 such that the left parts contain the same characters (so do the right parts).
            // For example: s1 = "great", s2 = "rgeta", they can be split into:
            // gr | eat
            // rg | eta
            // This is a necessary condition in which s2 is a scrambled string of s1. Then we have two sub-problems.
            // But don't forget the left part of s1 can also be equal(that is, contains the same characters) to the right part of s2.
            // For example: s1 = "great", s2 = "eatgr"
            // gr | eat
            // eat | gr
            if (s1 == s2) return true;
            var CharCounts1 = new Dictionary<char, int>();
            var CharCounts2FromStart = new Dictionary<char, int>();
            var CharCounts2FromEnd = new Dictionary<char, int>();
            for (int i = 0, fromStart = 0, fromEnd = s2.Length - 1; i < s1.Length - 1; i++)
            {
                CharCounts1[s1[i]] = CharCounts1.GetValueOrDefault(s1[i]) + 1;

                for (; fromStart <= i; fromStart++)
                {
                    if (CharCounts1.TryGetValue(s2[fromStart], out int count1))
                    {
                        int count2 = CharCounts2FromStart.GetValueOrDefault(s2[fromStart]) + 1;
                        if (count2 > count1) break; // "count2 < count1" is OK because there may be more of this character next.
                        CharCounts2FromStart[s2[fromStart]] = count2;
                    }
                    else break;
                }
                if (fromStart == i + 1 && CharCounts1.Count == CharCounts2FromStart.Count
                    && IsScramble(s1.Substring(0, i + 1), s2.Substring(0, i + 1))
                    && IsScramble(s1.Substring(i + 1), s2.Substring(i + 1))) return true;

                for (; fromEnd >= s2.Length - i - 1; fromEnd--)
                {
                    if (CharCounts1.TryGetValue(s2[fromEnd], out int count1))
                    {
                        int count2 = CharCounts2FromEnd.GetValueOrDefault(s2[fromEnd]) + 1;
                        if (count2 > count1) break;
                        CharCounts2FromEnd[s2[fromEnd]] = count2;
                    }
                    else break;
                }
                if (fromEnd == s2.Length - i - 2 && CharCounts1.Count == CharCounts2FromEnd.Count
                    && IsScramble(s1.Substring(0, i + 1), s2.Substring(s1.Length - i - 1))
                    && IsScramble(s1.Substring(i + 1), s2.Substring(0, s1.Length - i - 1))) return true;
            }
            return false;
        }
    }
}
