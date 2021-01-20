using System;

namespace Algorithms.LeetCode
{
    /* 521. Longest Uncommon Subsequence I
     * 
     * Given two strings a and b, find the length of the longest uncommon subsequence
     * between them.
     * 
     * An uncommon subsequence between two strings is a string that is a subsequence
     * of one but not the other.
     * 
     * Return the length of the longest uncommon subsequence between a and b. If the
     * longest uncommon subsequence doesn't exist, return -1.
     * 
     * Example 1:
     * 
     * Input: a = "aba", b = "cdc"
     * Output: 3
     * Explanation: One longest uncommon subsequence is "aba" because "aba" is a
     * subsequence of "aba" but not "cdc".
     * Note that "cdc" is also a longest uncommon subsequence.
     * 
     * Example 2:
     * 
     * Input: a = "aaa", b = "bbb"
     * Output: 3
     * Explanation: The longest uncommon subsequences are "aaa" and "bbb".
     * 
     * Example 3:
     * 
     * Input: a = "aaa", b = "aaa"
     * Output: -1
     * Explanation: Every subsequence of string a is also a subsequence of string b.
     * Similarly, every subsequence of string b is also a subsequence of string a.
     */
    public class Longest_Uncommon_Subsequence_I
    {
        public int FindLUSlength(string a, string b)
        {
            return a == b ? -1 : Math.Max(a.Length, b.Length);
        }
    }
}
