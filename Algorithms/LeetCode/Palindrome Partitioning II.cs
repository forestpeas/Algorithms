using System;

namespace Algorithms.LeetCode
{
    /* 132. Palindrome Partitioning II
     * 
     * Given a string s, partition s such that every substring of the partition is a palindrome.
     * Return the minimum cuts needed for a palindrome partitioning of s.
     * 
     * Example:
     * 
     * Input: "aab"
     * Output: 1
     * Explanation: The palindrome partitioning ["aa","b"] could be produced using 1 cut.
     */
    public class PalindromePartitioningII
    {
        public int MinCut(string s)
        {
            // Similar to "Problem 5. Longest Palindromic Substring"'s DP solution.
            // isPalindrome[j, i] means whether s[j...i] is a palindrome.
            // cut[i] is the minimum cuts for s[0...i].
            bool[,] isPalindrome = new bool[s.Length, s.Length];
            int[] cut = new int[s.Length];

            for (int i = 0; i < s.Length; i++)
            {
                cut[i] = i; // For s[0...i], we need at most i cuts(when none of s[0...i]'s substrings is palindromic).
                for (int j = 0; j <= i; j++)
                {
                    if (s[j] == s[i] && (j + 1 >= i - 1 || isPalindrome[j + 1, i - 1]))
                    {
                        // s[j...i] is a palindrom, so we can cut between j - 1 and j.
                        isPalindrome[j, i] = true;
                        cut[i] = j == 0 ? 0 : Math.Min(cut[i], cut[j - 1] + 1);
                    }
                }
            }

            return cut[s.Length - 1];
        }
    }
}
