using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 421. Maximum XOR of Two Numbers in an Array
     * 
     * Given a non-empty array of numbers, a0, a1, a2, … , an-1, where 0 ≤ ai < 231.
     * Find the maximum result of ai XOR aj, where 0 ≤ i, j < n.
     * 
     * Could you do this in O(n) runtime?
     * 
     * Example:
     * Input: [3, 10, 5, 25, 2, 8]
     * Output: 28
     * Explanation: The maximum result is 5 ^ 25 = 28.
     */
    public class Maximum_XOR_of_Two_Numbers_in_an_Array
    {
        public int FindMaximumXOR(int[] nums)
        {
            // First we check whether the MSB can be 1, then the second MSB...
            int result = 0;
            int mask = 0;
            for (int i = 31; i >= 0; i--)
            {
                // Only considering a prefix of the numbers.
                mask = mask | (1 << i);
                var set = new HashSet<int>();
                foreach (int n in nums) set.Add(n & mask);
                int greedyTry = result | (1 << i);
                foreach (int prefix in set)
                {
                    // This is like finding a target sum within an array: a + b = sum, a = sum - b.
                    // Similarly, a ^ b = c, a = c ^ b.
                    // The pair of numbers that has the maximum XOR will always "stand out".
                    if (set.Contains(greedyTry ^ prefix))
                    {
                        result = greedyTry;
                        break;
                    }
                }
            }
            return result;
        }
    }
}
