namespace Algorithms.LeetCode
{
    /* 5. Longest Palindromic Substring
     * 
     * Given a string s, find the longest palindromic substring in s. You may assume that the maximum length of s is 1000.
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
        // Your runtime beats 42.41 % of csharp submissions.
        // Your memory usage beats 13.21 % of csharp submissions.
        public string LongestPalindrome(string s)
        {
            // DP solution
            if (s == string.Empty) return string.Empty;

            int resultStart = 0;
            int resultLength = 0;

            // Because default value is false, so we let "mem[i,j] = false" means "s[i]~s[j] is a palindrome". 
            // Thus we don't have to initialize all the mem[x,y] when x = y.
            bool[,] mem = new bool[s.Length, s.Length];

            for (int i = 1; i < s.Length; i++)
            {
                if (s[i - 1] != s[i])
                {
                    mem[i - 1, i] = true;
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
                    if (s[start] != s[end] || mem[start + 1, end - 1])
                    {
                        mem[start, end] = true;
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
