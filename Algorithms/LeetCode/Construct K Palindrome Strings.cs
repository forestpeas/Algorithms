using System.Linq;

namespace Algorithms.LeetCode
{
    /* 1400. Construct K Palindrome Strings
     * 
     * Given a string s and an integer k. You should construct k non-empty palindrome strings using all
     * the characters in s.
     * 
     * Return True if you can use all the characters in s to construct k palindrome strings or False
     * otherwise.
     * 
     * Example 1:
     * 
     * Input: s = "annabelle", k = 2
     * Output: true
     * Explanation: You can construct two palindromes using all characters in s.
     * Some possible constructions "anna" + "elble", "anbna" + "elle", "anellena" + "b"
     * 
     * Example 2:
     * 
     * Input: s = "leetcode", k = 3
     * Output: false
     * Explanation: It is impossible to construct 3 palindromes using all the characters of s.
     * 
     * Example 3:
     * 
     * Input: s = "true", k = 4
     * Output: true
     * Explanation: The only possible solution is to put each character in a separate string.
     * 
     * Example 4:
     * 
     * Input: s = "yzyzyzyzyzyzyzy", k = 2
     * Output: true
     * Explanation: Simply you can put all z's in one string and all y's in the other string. Both
     * strings will be palindrome.
     * 
     * Example 5:
     * 
     * Input: s = "cr", k = 7
     * Output: false
     * Explanation: We don't have enough characters in s to construct 7 palindromes.
     */
    public class Construct_K_Palindrome_Strings
    {
        public bool CanConstruct(string s, int k)
        {
            // Similar to "409. Longest Palindrome".
            // Count the number of the characters that appear an odd number of times.
            if (k > s.Length) return false;
            bool[] odds = new bool[26];
            foreach (char c in s)
            {
                odds[c - 'a'] = !odds[c - 'a'];
            }
            return odds.Count(odd => odd) <= k;
        }
    }
}
