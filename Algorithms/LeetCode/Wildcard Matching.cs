namespace Algorithms.LeetCode
{
    /* 44. Wildcard Matching
     * 
     * Given an input string (s) and a pattern (p), implement wildcard pattern matching with support for '?' and '*'.
     * '?' Matches any single character.
     * '*' Matches any sequence of characters (including the empty sequence).
     * The matching should cover the entire input string (not partial).
     * 
     * Note:
     * 
     * s could be empty and contains only lowercase letters a-z.
     * p could be empty and contains only lowercase letters a-z, and characters like ? or *.
     *  
     * Example 1:
     * 
     * Input:
     * s = "aa"
     * p = "a"
     * Output: false
     * Explanation: "a" does not match the entire string "aa".
     *  
     * Example 2:
     * 
     * Input:
     * s = "aa"
     * p = "*"
     * Output: true
     * Explanation: '*' matches any sequence.
     *  
     * Example 3:
     * 
     * Input:
     * s = "cb"
     * p = "?a"
     * Output: false
     * Explanation: '?' matches 'c', but the second letter is 'a', which does not match 'b'.
     *  
     * Example 4:
     * 
     * Input:
     * s = "adceb"
     * p = "*a*b"
     * Output: true
     * Explanation: The first '*' matches the empty sequence, while the second '*' matches the substring "dce".
     *  
     * Example 5:
     * 
     * Input:
     * s = "acdcb"
     * p = "a*c?b"
     * Output: false
     */
    public class WildcardMatching
    {
        public bool IsMatch(string s, string p)
        {
            // Dynamic programming. Similar to "10. Regular Expression Matching".
            bool[,] mem = new bool[s.Length + 1, p.Length + 1];

            mem[0, 0] = true;
            for (int i = 1; i <= s.Length; i++)
            {
                mem[i, 0] = false;
            }
            for (int j = 1; j <= p.Length; j++)
            {
                mem[0, j] = p[j - 1] == '*' && mem[0, j - 1];
            }

            for (int i = 1; i <= s.Length; i++)
            {
                for (int j = 1; j <= p.Length; j++)
                {
                    if (p[j - 1] != '*')
                    {
                        mem[i, j] = mem[i - 1, j - 1] && (s[i - 1] == p[j - 1] || '?' == p[j - 1]);
                    }
                    else
                    {
                        // '*' matches empty(for example: s = "ab", p = "ab*).
                        // Or, '*' swallows a new character(that is s[i-1]).
                        mem[i, j] = mem[i, j - 1] || mem[i - 1, j];
                    }
                }
            }

            return mem[s.Length, p.Length];
        }

        public bool IsMatchWithConstantSpace(string s, string p)
        {
            // i is a pointer for the string, and j is a pointer for thr pattern.
            // When a '*' is found, ii records i and jj records j.
            int i = 0, j = 0, ii = 0, jj = -1;
            while (i < s.Length)
            {
                if (j < p.Length && (p[j] == '?' || s[i] == p[j]))
                {
                    i++;
                    j++;
                }
                // When a '*' is found, first we assume the '*' matches empty.
                else if (j < p.Length && p[j] == '*')
                {
                    jj = j;
                    ii = i;
                    j++;
                }
                // Dead end. We have to go back and let the last '*' swallow one more character.
                else if (jj != -1)
                {
                    j = jj + 1;
                    i = ++ii;
                }
                else return false;
            }

            while (j < p.Length && p[j] == '*') j++;

            return j == p.Length;
        }
    }
}
