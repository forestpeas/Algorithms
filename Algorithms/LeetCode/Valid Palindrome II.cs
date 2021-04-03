namespace Algorithms.LeetCode
{
    /* 680. Valid Palindrome II
     * 
     * Given a non-empty string s, you may delete at most one character. Judge whether you can make it a palindrome.
     * 
     * Example 1:
     * Input: "aba"
     * Output: True
     * 
     * Example 2:
     * Input: "abca"
     * Output: True
     * Explanation: You could delete the character 'c'.
     */
    public class Valid_Palindrome_II
    {
        public bool ValidPalindrome(string s)
        {
            int lo = 0, hi = s.Length - 1;
            while (lo < hi)
            {
                if (s[lo] != s[hi])
                {
                    return IsPalindrome(s, lo, hi - 1) || IsPalindrome(s, lo + 1, hi);
                }
                lo++;
                hi--;
            }
            return true;
        }

        private bool IsPalindrome(string s, int lo, int hi)
        {
            while (lo < hi)
            {
                if (s[lo] != s[hi]) return false;
                lo++;
                hi--;
            }
            return true;
        }
    }
}
