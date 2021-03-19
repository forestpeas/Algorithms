using System;

namespace Algorithms.LeetCode
{
    /* 650. 2 Keys Keyboard
     * 
     * Initially on a notepad only one character 'A' is present. You can perform two operations on this
     * notepad for each step:
     * 
     * Copy All: You can copy all the characters present on the notepad (partial copy is not allowed).
     * Paste: You can paste the characters which are copied last time. 
     * 
     * Given a number n. You have to get exactly n 'A' on the notepad by performing the minimum number
     * of steps permitted. Output the minimum number of steps to get n 'A'.
     * 
     * Example 1:
     * 
     * Input: 3
     * Output: 3
     * Explanation:
     * Intitally, we have one character 'A'.
     * In step 1, we use Copy All operation.
     * In step 2, we use Paste operation to get 'AA'.
     * In step 3, we use Paste operation to get 'AAA'.
     */
    public class _2_Keys_Keyboard
    {
        public int MinSteps(int n)
        {
            int[,] mem = new int[n + 1, n + 1];
            return Helper(1, 0);

            int Helper(int written, int copied)
            {
                if (written == n) return 0;
                if (written > n) return int.MaxValue;
                if (mem[written, copied] != 0) return mem[written, copied];
                int res = int.MaxValue;
                if (written > copied) res = Helper(written, written);
                if (copied > 0) res = Math.Min(res, Helper(written + copied, copied));
                mem[written, copied] = res == int.MaxValue ? int.MaxValue : res + 1;
                return mem[written, copied];
            }
        }

        class Approach2
        {
            public int MinSteps(int n)
            {
                if (n == 1) return 0;
                for (int i = 2; i < n; i++)
                {
                    if (n % i == 0) return MinSteps(n / i) + i;
                }
                return n;
            }
        }
    }
}
