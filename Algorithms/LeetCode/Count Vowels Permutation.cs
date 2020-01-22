namespace Algorithms.LeetCode
{
    /* 1220. Count Vowels Permutation
     * 
     * Given an integer n, your task is to count how many strings of length n can be formed under the
     * following rules:
     * 
     * Each character is a lower case vowel ('a', 'e', 'i', 'o', 'u')
     * Each vowel 'a' may only be followed by an 'e'.
     * Each vowel 'e' may only be followed by an 'a' or an 'i'.
     * Each vowel 'i' may not be followed by another 'i'.
     * Each vowel 'o' may only be followed by an 'i' or a 'u'.
     * Each vowel 'u' may only be followed by an 'a'.
     * Since the answer may be too large, return it modulo 10^9 + 7.
     * 
     * Example 1:
     * 
     * Input: n = 1
     * Output: 5
     * Explanation: All possible strings are: "a", "e", "i" , "o" and "u".
     * 
     * Example 2:
     * 
     * Input: n = 2
     * Output: 10
     * Explanation: All possible strings are: "ae", "ea", "ei", "ia", "ie", "io", "iu", "oi", "ou" and "ua".
     * 
     * Example 3: 
     * 
     * Input: n = 5
     * Output: 68
     */
    public class Count_Vowels_Permutation
    {
        public int CountVowelPermutation(int n)
        {
            // DP. dp[i]['a'] means the number of possible strings of length i that ends with an 'a'.
            int mod = 1000000007;
            long a = 1, e = 1, i = 1, o = 1, u = 1;
            while (n-- > 1)
            {
                long a_next = e + i + u;
                long e_next = a + i;
                long i_next = e + o;
                long o_next = i;
                long u_next = i + o;

                a = a_next % mod;
                e = e_next % mod;
                i = i_next % mod;
                o = o_next % mod;
                u = u_next % mod;
            }

            return (int)((a + e + i + o + u) % mod);
        }
    }
}
