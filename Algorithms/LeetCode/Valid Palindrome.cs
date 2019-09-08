namespace Algorithms.LeetCode
{
    /* 125. Valid Palindrome
     * 
     * Given a string, determine if it is a palindrome, considering only alphanumeric characters and ignoring cases.
     * 
     * Note: For the purpose of this problem, we define empty string as valid palindrome.
     * 
     * Example 1:
     * 
     * Input: "A man, a plan, a canal: Panama"
     * Output: true
     * 
     * Example 2:
     * 
     * Input: "race a car"
     * Output: false
     */
    public class ValidPalindrome
    {
        public bool IsPalindrome(string s)
        {
            int lo = 0;
            int hi = s.Length - 1;
            while (lo < hi)
            {
                if (!char.IsLetterOrDigit(s[lo]))
                {
                    lo++;
                    continue;
                }

                if (!char.IsLetterOrDigit(s[hi]))
                {
                    hi--;
                    continue;
                }

                if (char.ToLower(s[lo]) != char.ToLower(s[hi])) return false;
                lo++;
                hi--;
            }

            return true;
        }
    }
}
