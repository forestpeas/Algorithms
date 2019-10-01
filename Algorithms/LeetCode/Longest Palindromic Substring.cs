namespace Algorithms.LeetCode
{
    /* 5. Longest Palindromic Substring
     * 
     * Given a string s, find the longest palindromic substring in s.
     * You may assume that the maximum length of s is 1000.
     * 
     * Example 1:
     * 
     * Input: "babad"
     * Output: "bab"
     * Note: "aba" is also a valid answer.
     * 
     * Example 2:
     * 
     * Input: "cbbd"
     * Output: "bb"
     */
    public class LongestPalindromicSubstring
    {
        public string LongestPalindrome(string s)
        {
            // DP solution.
            int resultStart = 0;
            int resultLength = 0;
            // dp[i,j] means whether s[i]~s[j] is a palindrome. 
            bool[,] dp = new bool[s.Length, s.Length];

            for (int i = 0; i < s.Length; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (s[j] == s[i] && (j + 1 >= i - 1 || dp[j + 1, i - 1]))
                    {
                        dp[j, i] = true;
                        if (i - j + 1 > resultLength)
                        {
                            resultLength = i - j + 1;
                            resultStart = j;
                        }
                    }
                }
            }

            return s.Substring(resultStart, resultLength);
        }
    }
}
