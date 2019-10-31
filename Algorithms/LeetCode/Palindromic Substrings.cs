namespace Algorithms.LeetCode
{
    /* 647. Palindromic Substrings
     * 
     * Given a string, your task is to count how many palindromic substrings in this string.
     * 
     * The substrings with different start indexes or end indexes are counted as different
     * substrings even they consist of same characters.
     * 
     * Example 1:
     * 
     * Input: "abc"
     * Output: 3
     * Explanation: Three palindromic strings: "a", "b", "c".
     * 
     * Example 2:
     * 
     * Input: "aaa"
     * Output: 6
     * Explanation: Six palindromic strings: "a", "a", "a", "aa", "aa", "aaa".
     * 
     * Note: 
     * The input string length won't exceed 1000.
     */
    public class PalindromicSubstrings
    {
        public int CountSubstrings(string s)
        {
            // Same as "5. Longest Palindromic Substring".
            int result = 0;
            // dp[i,j] means whether s[i]~s[j] is a palindrome. 
            bool[,] dp = new bool[s.Length, s.Length];

            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (s[j] == s[i] && (j + 1 >= i - 1 || dp[j + 1, i - 1]))
                    {
                        dp[j, i] = true;
                        result++;
                    }
                }
            }

            return result;
        }
    }
}
