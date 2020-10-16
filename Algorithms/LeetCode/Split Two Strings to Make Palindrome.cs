namespace Algorithms.LeetCode
{
    /* 1616. Split Two Strings to Make Palindrome
     * 
     * You are given two strings a and b of the same length. Choose an index and split both strings at
     * the same index, splitting a into two strings: aprefix and asuffix where a = aprefix + asuffix,
     * and splitting b into two strings: bprefix and bsuffix where b = bprefix + bsuffix. Check if
     * aprefix + bsuffix or bprefix + asuffix forms a palindrome.
     * 
     * When you split a string s into sprefix and ssuffix, either ssuffix or sprefix is allowed to b
     * e empty. For example, if s = "abc", then "" + "abc", "a" + "bc", "ab" + "c" , and "abc" + ""
     * are valid splits.
     * 
     * Return true if it is possible to form a palindrome string, otherwise return false.
     * 
     * Notice that x + y denotes the concatenation of strings x and y.
     * 
     * Example 1:
     * 
     * Input: a = "x", b = "y"
     * Output: true
     * Explaination: If either a or b are palindromes the answer is true since you can split in the
     * following way:
     * aprefix = "", asuffix = "x"
     * bprefix = "", bsuffix = "y"
     * Then, aprefix + bsuffix = "" + "y" = "y", which is a palindrome.
     * 
     * Example 2:
     * 
     * Input: a = "abdef", b = "fecab"
     * Output: true
     * 
     * Example 3:
     * 
     * Input: a = "ulacfd", b = "jizalu"
     * Output: true
     * Explaination: Split them at index 3:
     * aprefix = "ula", asuffix = "cfd"
     * bprefix = "jiz", bsuffix = "alu"
     * Then, aprefix + bsuffix = "ula" + "alu" = "ulaalu", which is a palindrome.
     * 
     * Example 4:
     * 
     * Input: a = "xbdef", b = "xecab"
     * Output: false
     */
    public class Split_Two_Strings_to_Make_Palindrome
    {
        public bool CheckPalindromeFormation(string a, string b)
        {
            return CheckCore(a, b) || CheckCore(b, a);
        }

        private bool CheckCore(string a, string b)
        {
            int n = b.Length;
            for (int i = 0; i < n / 2; i++)
            {
                if (a[i] != b[n - 1 - i])
                {
                    return IsPalindrome(a, i, n - 1 - i) || IsPalindrome(b, i, n - 1 - i);
                }
            }
            return true;
        }

        private bool IsPalindrome(string s, int start, int end)
        {
            while (start <= end)
            {
                if (s[start++] != s[end--]) return false;
            }
            return true;
        }
    }
}
