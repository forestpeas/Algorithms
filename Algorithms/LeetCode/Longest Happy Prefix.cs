namespace Algorithms.LeetCode
{
    /* 1392. Longest Happy Prefix
     * 
     * A string is called a happy prefix if is a non-empty prefix which is also a suffix (excluding itself).
     * 
     * Given a string s. Return the longest happy prefix of s .
     * 
     * Return an empty string if no such prefix exists.
     * 
     * Example 1:
     * 
     * Input: s = "level"
     * Output: "l"
     * Explanation: s contains 4 prefix excluding itself ("l", "le", "lev", "leve"), and suffix ("l", "el", "vel", "evel").
     * The largest prefix which is also suffix is given by "l".
     * Example 2:
     * 
     * Input: s = "ababab"
     * Output: "abab"
     * Explanation: "abab" is the largest prefix which is also suffix. They can overlap in the original string.
     * Example 3:
     * 
     * Input: s = "leetcodeleet"
     * Output: "leet"
     * Example 4:
     * 
     * Input: s = "a"
     * Output: ""
     */
    public class Longest_Happy_Prefix
    {
        public string LongestPrefix(string s)
        {
            // Same as the initialization of KMP.
            int[] next = new int[s.Length + 1];
            int i = 1;
            int j = 0;
            while (i < s.Length)
            {
                if (s[i] == s[j])
                {
                    i++;
                    j++;
                    next[i] = j;
                }
                else if (j == 0)
                {
                    i++;
                }
                else
                {
                    j = next[j];
                }
            }

            return s.Substring(0, next[s.Length]);
        }

        public string LongestPrefix2(string s)
        {
            // Rolling hash
            long l = 0, r = 0, mul = 1, mod = 1000000007;
            int n = s.Length, res = 0;
            for (int i = 0; i < n - 1; i++)
            {
                l = (l * 128 + s[i]) % mod;
                r = (s[n - i - 1] * mul + r) % mod;
                if (l == r) res = i + 1;
                mul = mul * 128 % mod;
            }
            return s.Substring(0, res);
        }
    }
}
