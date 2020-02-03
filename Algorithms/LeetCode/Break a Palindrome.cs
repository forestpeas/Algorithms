namespace Algorithms.LeetCode
{
    /* 1328. Break a Palindrome
     * 
     * Given a palindromic string palindrome, replace exactly one character by any lowercase English letter
     * so that the string becomes the lexicographically smallest possible string that isn't a palindrome.
     * 
     * After doing so, return the final string.  If there is no way to do so, return the empty string.
     * 
     * Example 1:
     * 
     * Input: palindrome = "abccba"
     * Output: "aaccba"
     * 
     * Example 2:
     * 
     * Input: palindrome = "a"
     * Output: ""
     */
    public class Break_a_Palindrome
    {
        public string BreakPalindrome(string palindrome)
        {
            // Just consider all possible cases.
            char[] str = palindrome.ToCharArray();
            for (int i = 0; i < str.Length / 2; i++)
            {
                if (str[i] != 'a')
                {
                    str[i] = 'a';
                    return new string(str);
                }
            }

            if (palindrome.Length < 2) return string.Empty;
            str[str.Length - 1] = 'b';
            return new string(str);
        }
    }
}
