using System;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 384. Shuffle an Array
     * 
     * Shuffle a set of numbers without duplicates.
     * 
     * Example:
     * 
     * // Init an array with set 1, 2, and 3.
     * int[] nums = {1,2,3};
     * Solution solution = new Solution(nums);
     * 
     * // Shuffle the array [1,2,3] and return its result. Any permutation of [1,2,3] must equally likely to be returned.
     * solution.shuffle();
     * 
     * // Resets the array back to its original configuration [1,2,3].
     * solution.reset();
     * 
     * // Returns the random shuffling of array [1,2,3].
     * solution.shuffle();
     */
    public class ShuffleAnArraySolution
    {
        public class Solution
        {
            private readonly int[] _nums;
            private readonly int[] _original;
            private readonly Random _random = new Random();

            public Solution(int[] nums)
            {
                _nums = nums;
                _original = nums.ToArray();
            }

            /** Resets the array to its original configuration and return it. */
            public int[] Reset()
            {
                Array.Copy(_original, _nums, _nums.Length);
                return _nums;
            }

            /** Returns a random shuffling of the array. */
            public int[] Shuffle()
            {
                // Fisher-Yates algorithm. Randomly choose a number from [i, length) and put it
                // at the front of the array as the chosen numbers.
                for (int i = 0; i < _nums.Length; i++)
                {
                    Swap(i, _random.Next(i, _nums.Length));
                }
                return _nums;
            }

            private void Swap(int i, int j)
            {
                int tmp = _nums[i];
                _nums[i] = _nums[j];
                _nums[j] = tmp;
            }
        }
    }
}
