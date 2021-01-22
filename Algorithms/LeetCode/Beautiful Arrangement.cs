using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 526. Beautiful Arrangement
     * 
     * Suppose you have n integers labeled 1 through n. A permutation of those n integers perm
     * (1-indexed) is considered a beautiful arrangement if for every i (1 <= i <= n), either
     * of the following is true:
     * 
     * perm[i] is divisible by i.
     * i is divisible by perm[i].
     * Given an integer n, return the number of the beautiful arrangements that you can construct.
     * 
     * Example 1:
     * 
     * Input: n = 2
     * Output: 2
     * Explanation: 
     * The first beautiful arrangement is [1,2]:
     *     - perm[1] = 1 is divisible by i = 1
     *     - perm[2] = 2 is divisible by i = 2
     * The second beautiful arrangement is [2,1]:
     *     - perm[1] = 2 is divisible by i = 1
     *     - i = 2 is divisible by perm[2] = 1
     *     
     * Example 2:
     * 
     * Input: n = 1
     * Output: 1
     */
    public class Beautiful_Arrangement
    {
        public int CountArrangement(int n)
        {
            var mem = new Dictionary<string, int>();
            bool[] marked = new bool[n + 1];
            return Helper(1);

            int Helper(int i)
            {
                if (i > n) return 1;
                string key = string.Join(' ', marked.Select(m => m ? 1 : 0));
                if (mem.TryGetValue(key, out int res)) return res;
                for (int num = 1; num <= n; num++)
                {
                    if (marked[num]) continue;
                    if ((num % i != 0) && (i % num != 0)) continue;
                    marked[num] = true;
                    res += Helper(i + 1);
                    marked[num] = false;
                }
                mem.Add(key, res);
                return res;
            }
        }
    }
}
