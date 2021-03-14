using System.Linq;

namespace Algorithms.LeetCode
{
    /* 646. Maximum Length of Pair Chain
     * 
     * You are given n pairs of numbers. In every pair, the first number is always smaller
     * than the second number.
     * 
     * Now, we define a pair (c, d) can follow another pair (a, b) if and only if b < c.
     * Chain of pairs can be formed in this fashion.
     * 
     * Given a set of pairs, find the length longest chain which can be formed. You needn't
     * use up all the given pairs. You can select pairs in any order.
     * 
     * Example 1:
     * 
     * Input: [[1,2], [2,3], [3,4]]
     * Output: 2
     * Explanation: The longest chain is [1,2] -> [3,4]
     */
    public class Maximum_Length_of_Pair_Chain
    {
        public int FindLongestChain(int[][] pairs)
        {
            // Same as "435. Non-overlapping Intervals".
            pairs = pairs.OrderBy(p => p[1]).ToArray();
            int r = pairs[0][1];
            int res = 1;
            foreach (int[] pair in pairs)
            {
                if (pair[0] > r)
                {
                    r = pair[1];
                    res++;
                }
            }
            return res;
        }
    }
}
