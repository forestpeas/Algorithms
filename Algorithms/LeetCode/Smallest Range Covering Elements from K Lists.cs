using Algorithms.DataStructures;
using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 632. Smallest Range Covering Elements from K Lists
     * 
     * You have k lists of sorted integers in non-decreasing order. Find the smallest range that includes
     * at least one number from each of the k lists.
     * 
     * We define the range [a, b] is smaller than range [c, d] if b - a < d - c or a < c if b - a == d - c. 
     * 
     * Example 1:
     * 
     * Input: nums = [[4,10,15,24,26],[0,9,12,20],[5,18,22,30]]
     * Output: [20,24]
     * Explanation: 
     * List 1: [4, 10, 15, 24,26], 24 is in range [20,24].
     * List 2: [0, 9, 12, 20], 20 is in range [20,24].
     * List 3: [5, 18, 22, 30], 22 is in range [20,24].
     * 
     * Example 2:
     * 
     * Input: nums = [[1,2,3],[1,2,3],[1,2,3]]
     * Output: [1,1]
     * 
     * Example 3:
     * 
     * Input: nums = [[10,10],[11,11]]
     * Output: [10,11]
     * 
     * Example 4:
     * 
     * Input: nums = [[10],[11]]
     * Output: [10,11]
     * 
     * Example 5:
     * 
     * Input: nums = [[1],[2],[3],[4],[5],[6],[7]]
     * Output: [1,7]
     * 
     * Constraints:
     * 
     * nums.length == k
     * 1 <= k <= 3500
     * 1 <= nums[i].length <= 50
     */
    public class Smallest_Range_Covering_Elements_from_K_Lists
    {
        public int[] SmallestRange(IList<IList<int>> nums)
        {
            var pq = new PriorityQueue<(int i, int j)>(Comparer<(int i, int j)>.Create((x, y) => nums[y.i][y.j].CompareTo(nums[x.i][x.j])));
            int max = int.MinValue;
            for (int i = 0; i < nums.Count; i++)
            {
                pq.Add((i, 0));
                max = Math.Max(max, nums[i][0]);
            }

            int resRange = int.MaxValue, resMin = -1, resMax = -1;
            while (pq.Count == nums.Count)
            {
                var (i, j) = pq.DeleteTop(); // the indexes of the element with the minimum value so far
                int range = max - nums[i][j];
                if (range < resRange)
                {
                    resRange = range;
                    resMin = nums[i][j];
                    resMax = max;
                }
                if (j + 1 < nums[i].Count)
                {
                    pq.Add((i, j + 1));
                    max = Math.Max(max, nums[i][j + 1]);
                }
            }
            return new int[] { resMin, resMax };
        }
    }
}
