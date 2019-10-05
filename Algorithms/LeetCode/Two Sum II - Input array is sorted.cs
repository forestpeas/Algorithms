using System;

namespace Algorithms.LeetCode
{
    /* 167. Two Sum II - Input array is sorted
     * 
     * Given an array of integers that is already sorted in ascending order, find two numbers such that
     * they add up to a specific target number.
     * 
     * The function twoSum should return indices of the two numbers such that they add up to the target,
     * where index1 must be less than index2.
     * 
     * Note:
     * Your returned answers (both index1 and index2) are not zero-based.
     * You may assume that each input would have exactly one solution and you may not use the same element twice.
     * 
     * Example:
     * 
     * Input: numbers = [2,7,11,15], target = 9
     * Output: [1,2]
     * Explanation: The sum of 2 and 7 is 9. Therefore index1 = 1, index2 = 2.
     */
    public class TwoSumII_InputArrayIsSorted
    {
        public int[] TwoSum(int[] numbers, int target)
        {
            // High-low pointers, similar to "11. Container With Most Water".
            int lo = 0, hi = numbers.Length - 1;
            while (lo < hi)
            {
                if (numbers[lo] + numbers[hi] > target)
                {
                    hi--;
                }
                else if (numbers[lo] + numbers[hi] < target)
                {
                    lo++;
                }
                else
                {
                    return new int[] { lo + 1, hi + 1 };
                }
            }

            return new int[] { -1, -1 }; // Invalid input.
        }
        public int[] TwoSum2(int[] numbers, int target)
        {
            // My first attempt on this problem.
            // Try to find the complement of numbers[lo] in numbers[lo + 1,...,hi].
            // If found, simply return the result.
            // If not found, we can rule out numbers[lo] because the result must not contain number[0].
            // Note that the complement is always decreasing, so hi can also shrink.
            // I think the time complexity maybe is O(NlogN).
            int lo = 0;
            int hi = numbers.Length - 1;
            while (true)
            {
                int complement = target - numbers[lo];
                int idx = Array.BinarySearch(numbers, lo + 1, hi - lo, complement);
                if (idx > 0) return new int[] { lo + 1, idx + 1 };
                hi = ~idx - 1; // Next time, complement will only be smaller.
                lo++; // Rule out numbers[lo].
            }
        }
    }
}
