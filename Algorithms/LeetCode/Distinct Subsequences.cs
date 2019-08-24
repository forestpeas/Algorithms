namespace Algorithms.LeetCode
{
    /* 115. Distinct Subsequences
     * 
     * Given a string S and a string T, count the number of distinct subsequences of S which equals T.
     * 
     * A subsequence of a string is a new string which is formed from the original string by deleting
     * some (can be none) of the characters without disturbing the relative positions of the remaining
     * characters. (ie, "ACE" is a subsequence of "ABCDE" while "AEC" is not).
     * 
     * Example 1:
     * 
     * Input: S = "rabbbit", T = "rabbit"
     * Output: 3
     * Explanation:
     * 
     * As shown below, there are 3 ways you can generate "rabbit" from S.
     * (The caret symbol ^ means the chosen letters)
     * 
     * rabbbit
     * ^^^^ ^^
     * rabbbit
     * ^^ ^^^^
     * rabbbit
     * ^^^ ^^^
     * Example 2:
     * 
     * Input: S = "babgbag", T = "bag"
     * Output: 5
     * Explanation:
     * 
     * As shown below, there are 5 ways you can generate "bag" from S.
     * (The caret symbol ^ means the chosen letters)
     * 
     * babgbag
     * ^^ ^
     * babgbag
     * ^^    ^
     * babgbag
     * ^    ^^
     * babgbag
     *   ^  ^^
     * babgbag
     *     ^^^
     */
    public class DistinctSubsequences
    {
        public int NumDistinct(string s, string t)
        {
            if (t.Length == 0 || t.Length > s.Length) return 0;

            // DP solution. mem[i,j] means the answer of t[0...i] and s[0...j].
            // First, mem[i, j] is at least mem[i, j - 1], for example:
            // bab
            //  ba
            //   ↑
            //   i,j
            // ("ba","ba") = 1, ("bab","ba") = 1.
            // Second, if t[i] == s[j], there can be some new subsequences, for example:
            // bba
            //  ba
            //   ↑
            //   i,j
            // ("bb","b") = 2, so ("bba", "ba") is every answer of ("bb","b"), plus the
            // new "a".
            int[,] mem = new int[t.Length, s.Length]; // Can also be optimized to a single dimensional array.
            if (t[0] == s[0]) mem[0, 0] = 1;

            for (int j = 1; j < s.Length; j++)
            {
                mem[0, j] = mem[0, j - 1];
                if (t[0] == s[j]) mem[0, j]++;
            }

            for (int i = 1; i < t.Length; i++)
            {
                for (int j = i; j < s.Length; j++)
                {
                    mem[i, j] = mem[i, j - 1];
                    if (t[i] == s[j])
                    {
                        mem[i, j] += mem[i - 1, j - 1];
                    }
                }
            }
            return mem[t.Length - 1, s.Length - 1];
        }
    }
}
