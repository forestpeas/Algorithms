using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 409. Longest Palindrome
     * 
     * Given a string which consists of lowercase or uppercase letters, find the length
     * of the longest palindromes that can be built with those letters.
     * 
     * This is case sensitive, for example "Aa" is not considered a palindrome here.
     * 
     * Note:
     * Assume the length of given string will not exceed 1,010.
     * 
     * Example:
     * 
     * Input:
     * "abccccdd"
     * 
     * Output:
     * 7
     * 
     * Explanation:
     * One longest palindrome that can be built is "dccaccd", whose length is 7.
     */
    public class Longest_Palindrome
    {
        public int LongestPalindrome(string s)
        {
            // Find the letters that appear an odd number of times.
            var counts = new Dictionary<char, int>();
            foreach (char c in s) counts[c] = 1 + counts.GetValueOrDefault(c);

            int result = 0;
            bool hasOdd = false;
            foreach (int count in counts.Values)
            {
                if (count % 2 == 0) result += count;
                else
                {
                    result += count - 1; // Leave out the one in the middle.
                    hasOdd = true;
                }
            }

            return hasOdd ? result + 1 : result;
        }
    }
}
