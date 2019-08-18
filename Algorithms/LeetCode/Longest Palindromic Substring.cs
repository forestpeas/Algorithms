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
            if (s == string.Empty) return string.Empty;

            int resultStart = 0;
            int resultLength = 0;

            // mem[i,j] means weather s[i]~s[j] is a palindrome. 
            bool[,] mem = new bool[s.Length, s.Length];

            for (int i = 0; i < s.Length; i++)
            {
                mem[i, i] = true;
            }

            for (int i = 1; i < s.Length; i++)
            {
                if (s[i - 1] != s[i])
                {
                    mem[i - 1, i] = false;
                }
                else if (resultLength < 1)
                {
                    resultLength = 1;
                    resultStart = i - 1;
                }
            }

            for (int length = 2; length < s.Length; length++)
            {
                for (int end = length; end < s.Length; end++)
                {
                    int start = end - length;
                    if (s[start] != s[end] || !mem[start + 1, end - 1])
                    {
                        mem[start, end] = false;
                    }
                    else if (resultLength < length)
                    {
                        resultLength = length;
                        resultStart = start;
                    }
                }
            }

            return s.Substring(resultStart, resultLength + 1);
        }
    }
}
