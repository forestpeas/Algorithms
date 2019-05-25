namespace Algorithms.LeetCode
{
    /* 10. Regular Expression Matching
     * 
     * Given an input string (s) and a pattern (p), implement regular expression matching with support for '.' and '*'.
     * '.' Matches any single character.
     * '*' Matches zero or more of the preceding element.
     * The matching should cover the entire input string (not partial).
     * 
     * Note:
     * 
     * s could be empty and contains only lowercase letters a-z.
     * p could be empty and contains only lowercase letters a-z, and characters like . or *.
     * 
     * Example 1:
     * 
     * Input:
     * s = "aa"
     * p = "a"
     * Output: false
     * Explanation: "a" does not match the entire string "aa".
     * Example 2:
     * 
     * Input:
     * s = "aa"
     * p = "a*"
     * Output: true
     * Explanation: '*' means zero or more of the precedeng element, 'a'. Therefore, by repeating 'a' once, it becomes "aa".
     * Example 3:
     * 
     * Input:
     * s = "ab"
     * p = ".*"
     * Output: true
     * Explanation: ".*" means "zero or more (*) of any character (.)".
     * Example 4:
     * 
     * Input:
     * s = "aab"
     * p = "c*a*b"
     * Output: true
     * Explanation: c can be repeated 0 times, a can be repeated 1 time. Therefore it matches "aab".
     * Example 5:
     * 
     * Input:
     * s = "mississippi"
     * p = "mis*is*p*."
     * Output: false
     */
    public class RegularExpressionMatching
    {
        // Your runtime beats 70.23 % of csharp submissions.
        // Your memory usage beats 51.02 % of csharp submissions.
        public bool IsMatch(string s, string p)
        {
            int m = s.Length, n = p.Length;
            // Dynamic programming.
            // If s[0,..,i-1] matches p[0,...,j-1], then f[i,j] is true.
            // f[0,j] means the string is empty. f[i,0] means the pattern is empty.
            // We can get f[i,j] from f[i-1,j-1] and f[i,j-2], refer to the details below.
            bool[,] f = new bool[m + 1, n + 1];

            f[0, 0] = true;
            // First we settle f[1~m, 0].
            for (int i = 1; i <= m; i++)
            {
                f[i, 0] = false;
            }
            // Then we settle f[0, 1~n].
            // p[0,..., j - 3, j - 2, j - 1] matches empty string if p[j - 1] is '*' and p[0,...,j - 3] matches empty
            if (n > 0) f[0, 1] = false;
            for (int j = 2; j <= n; j++)
            {
                f[0, j] = '*' == p[j - 1] && f[0, j - 2];
            }

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (p[j - 1] != '*')
                    {
                        f[i, j] = f[i - 1, j - 1] && (s[i - 1] == p[j - 1] || '.' == p[j - 1]);
                    }
                    else // Assume the pattern is valid, so there must be something before '*', so j must > 2.
                    {
                        // Remove the last two char(that is x*) of pattern, still matches(so x* matches empty).
                        // Or, string adds some more matching chars to the x*.
                        f[i, j] = f[i, j - 2] || ((s[i - 1] == p[j - 2] || '.' == p[j - 2]) && f[i - 1, j]);
                    }
                }
            }

            return f[m, n];
        }
    }
}
