using System;
using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 398. Random Pick Index
     * 
     * Given an array of integers with possible duplicates, randomly output the index of a given
     * target number. You can assume that the given target number must exist in the array.
     * 
     * Example:
     * 
     * int[] nums = new int[] {1,2,3,3,3};
     * Solution solution = new Solution(nums);
     * 
     * // pick(3) should return either index 2, 3, or 4 randomly. Each index should have equal
     * // probability of returning.
     * solution.pick(3);
     * 
     * // pick(1) should return 0. Since in the array only nums[0] is equal to 1.
     * solution.pick(1);
     */
    public class Random_Pick_Index
    {
        public class Solution
        {
            private readonly Random _random = new Random();
            private readonly Dictionary<int, List<int>> _map = new Dictionary<int, List<int>>();

            public Solution(int[] nums)
            {
                for (int i = 0; i < nums.Length; i++)
                {
                    if (!_map.TryGetValue(nums[i], out var indexes))
                    {
                        indexes = new List<int>();
                        _map.Add(nums[i], indexes);
                    }

                    indexes.Add(i);
                }
            }

            public int Pick(int target)
            {
                var indexes = _map[target];
                return indexes[_random.Next(indexes.Count)];
            }
        }
    }
}
