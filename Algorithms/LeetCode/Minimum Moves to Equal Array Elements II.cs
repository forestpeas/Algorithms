using System;

namespace Algorithms.LeetCode
{
    /* 462. Minimum Moves to Equal Array Elements II
     * 
     * Given a non-empty integer array, find the minimum number of moves required to make
     * all array elements equal, where a move is incrementing a selected element by 1 or
     * decrementing a selected element by 1.
     * 
     * You may assume the array's length is at most 10,000.
     * 
     * Example:
     * 
     * Input:
     * [1,2,3]
     * 
     * Output:
     * 2
     * 
     * Explanation:
     * Only two moves are needed (remember each move increments or decrements one element):
     * 
     * [1,2,3]  =>  [2,2,3]  =>  [2,2,2]
     */
    public class Minimum_Moves_to_Equal_Array_Elements_II
    {
        public int MinMoves2(int[] nums)
        {
            // Another way to find the median: 215. Kth Largest Element in an Array.
            Array.Sort(nums);
            int median = nums[nums.Length / 2];
            int res = 0;
            foreach (int num in nums)
            {
                res += Math.Abs(num - median);
            }
            return res;
        }
    }
}
