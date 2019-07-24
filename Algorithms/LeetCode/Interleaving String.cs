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
        // DP solution.
        public bool IsInterleave(string s1, string s2, string s3)
        {
            if (s1 == string.Empty) return s2 == s3;
            if (s2 == string.Empty) return s1 == s3;
            if (s1.Length + s2.Length != s3.Length) return false;

            // Let mem[i,j] be whether s1[0...i-1] and s2[0...j-1] can form the interleaving string of s3[0...i+j-1].
            // mem[0,j] or mem[i,0] means "s1 is empty" or "s2 is empty".
            // mem[i+1,j+1] = (mem[i,j+1] && s1[i] == s3[i + j + 1]) || (mem[i+1,j] && s2[j] == s3[i + j + 1])
            // I can think it this way: if the corresponding s3 is "short of one character from s1", i.e. s1[i]
            // complete it by checking whether s1[i] == s3[i + j + 1]
            // And the same goes for s2.
            // As always, mem[i,j] can by optimized to a one-dimensional array.
            bool[] mem = new bool[s2.Length + 1];
            mem[0] = true;
            for (int j = 0; j < s1.Length; j++)
            {
                if (mem[j] && s2[j] == s3[j])
                {
                    mem[j + 1] = true;
                }
                else break;
            }

            for (int i = 0; i < s1.Length; i++)
            {
                mem[0] = mem[0] && s1[i] == s3[i];

                for (int j = 0; j < s2.Length; j++)
                {
                    mem[j + 1] = (mem[j + 1] && s1[i] == s3[i + j + 1]) || (mem[j] && s2[j] == s3[i + j + 1]);
                }
            }
            return mem[s2.Length];
        }

        // Recursive solution. Also backtracking.
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
