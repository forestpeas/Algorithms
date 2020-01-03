using System.Collections.Generic;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 1296. Divide Array in Sets of K Consecutive Numbers
     * 
     * Given an array of integers nums and a positive integer k, find whether it's possible to divide
     * this array into sets of k consecutive numbers
     * Return True if its possible otherwise return False.
     * 
     * Example 1:
     * 
     * Input: nums = [1,2,3,3,4,4,5,6], k = 4
     * Output: true
     * Explanation: Array can be divided into [1,2,3,4] and [3,4,5,6].
     * 
     * Example 2:
     * 
     * Input: nums = [3,2,1,2,3,4,3,4,5,9,10,11], k = 3
     * Output: true
     * Explanation: Array can be divided into [1,2,3] , [2,3,4] , [3,4,5] and [9,10,11].
     * 
     * Example 3:
     * 
     * Input: nums = [3,3,2,2,1,1], k = 3
     * Output: true
     * 
     * Example 4:
     * 
     * Input: nums = [1,2,3,4], k = 3
     * Output: false
     * Explanation: Each array should be divided in subarrays of size 3.
     * 
     * Constraints:
     * 1 <= nums.length <= 10^5
     * 1 <= nums[i] <= 10^9
     * 1 <= k <= nums.length
     */
    public class Divide_Array_in_Sets_of_K_Consecutive_Numbers
    {
        public bool IsPossibleDivide(int[] nums, int k)
        {
            // Similar to "128. Longest Consecutive Sequence".
            var counts = new SortedDictionary<int, int>(); // or Dictionary
            foreach (int num in nums) counts[num] = counts.GetValueOrDefault(num) + 1;

            while (counts.Count != 0)
            {
                int min = counts.Keys.First(); // and Min
                for (int i = 0; i < k; i++)
                {
                    if (!counts.ContainsKey(min + i)) return false;
                    if (--counts[min + i] == 0) counts.Remove(min + i);
                }
            }

            return true;
        }
    }
}
