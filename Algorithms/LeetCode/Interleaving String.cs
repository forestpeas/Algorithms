namespace Algorithms.LeetCode
{
    /* 97. Interleaving String
     * 
     * Given s1, s2, s3, find whether s3 is formed by the interleaving of s1 and s2.
     * 
     * Example 1:
     * 
     * Input: s1 = "aabcc", s2 = "dbbca", s3 = "aadbbcbcac"
     * Output: true
     * 
     * Example 2:
     * 
     * Input: s1 = "aabcc", s2 = "dbbca", s3 = "aadbbbaccc"
     * Output: false
     */
    public class InterleavingString
    {
        // Recursive solution.
        public bool IsInterleaveRecursive(string s1, string s2, string s3)
        {
            if (s1.Length + s2.Length != s3.Length) return false;
            return IsInterleave(s1, s2, s3, 0, 0, 0);
        }

        private bool IsInterleave(string s1, string s2, string s3, int i1, int i2, int i3)
        {
            if (i1 == s1.Length)
            {
                for (; i2 < s2.Length; i2++, i3++)
                {
                    if (s2[i2] != s3[i3]) return false;
                }
                return true;
            }
            if (i2 == s2.Length)
            {
                for (; i1 < s1.Length; i1++, i3++)
                {
                    if (s1[i1] != s3[i3]) return false;
                }
                return true;
            }
            if (s1[i1] == s3[i3])
            {
                if (IsInterleave(s1, s2, s3, i1 + 1, i2, i3 + 1)) return true;
            }
            if (s2[i2] == s3[i3])
            {
                if (IsInterleave(s1, s2, s3, i1, i2 + 1, i3 + 1)) return true;
            }
            return false;
        }
    }
}
