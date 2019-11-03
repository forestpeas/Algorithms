using System;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 214. Shortest Palindrome
     * 
     * Given a string s, you are allowed to convert it to a palindrome by adding
     * characters in front of it. Find and return the shortest palindrome you can
     * find by performing this transformation.
     * 
     * Example 1:
     * 
     * Input: "aacecaaa"
     * Output: "aaacecaaa"
     * Example 2:
     * 
     * Input: "abcd"
     * Output: "dcbabcd"
     */
    public class ShortestPalindromeSolution
    {
        public string ShortestPalindrome(string s)
        {
            // Find the longest palindrome starting from the beginning.
            // O(N^2) time complexity and O(1) space complexity.
            string r = new string(s.Reverse().ToArray());
            for (int i = 0; i < s.Length; i++)
            {
                if (s.StartsWith(r.Substring(i)))
                {
                    return r.Substring(0, i) + s;
                }
            }

            return "";
        }
    }
}
