using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 1304. Find N Unique Integers Sum up to Zero
     * 
     * Given an integer n, return any array containing n unique integers such that they add up to 0.
     * 
     * Example 1:
     * 
     * Input: n = 5
     * Output: [-7,-1,1,3,4]
     * Explanation: These arrays also are accepted [-5,-1,1,2,3] , [-3,-1,2,-2,4].
     * 
     * Example 2:
     * 
     * Input: n = 3
     * Output: [-1,0,1]
     * 
     * Example 3:
     * 
     * Input: n = 1
     * Output: [0]
     */
    public class Find_N_Unique_Integers_Sum_up_to_Zero
    {
        public int[] SumZero(int n)
        {
            var result = new List<int>(n);
            for (int i = 1; i <= n / 2; i++)
            {
                result.Add(i);
                result.Add(-i);
            }

            if (n % 2 == 1) result.Add(0);
            return result.ToArray();
        }
    }
}
