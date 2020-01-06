using System;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 1300. Sum of Mutated Array Closest to Target
     * 
     * Given an integer array arr and a target value target, return the integer value such that when
     * we change all the integers larger than value in the given array to be equal to value, the sum
     * of the array gets as close as possible (in absolute difference) to target.
     * 
     * In case of a tie, return the minimum such integer.
     * 
     * Notice that the answer is not neccesarilly a number from arr.
     * 
     * Example 1:
     * 
     * Input: arr = [4,9,3], target = 10
     * Output: 3
     * Explanation: When using 3 arr converts to [3, 3, 3] which sums 9 and that's the optimal answer.
     * 
     * Example 2:
     * 
     * Input: arr = [2,3,5], target = 10
     * Output: 5
     * 
     * Example 3:
     * 
     * Input: arr = [60864,25176,27249,21296,20204], target = 56803
     * Output: 11361
     * 
     * Constraints:
     * 
     *     1 <= arr.length <= 10^4
     *     1 <= arr[i], target <= 10^5
     */
    public class Sum_of_Mutated_Array_Closest_to_Target
    {
        public int FindBestValue(int[] arr, int target)
        {
            // Binary search.
            long minDiff = int.MaxValue;
            int result = int.MaxValue;
            int lo = 0;
            int hi = arr.Max() + 1;
            while (lo < hi)
            {
                int mid = lo + (hi - lo) / 2;
                long sum = 0;
                foreach (int num in arr)
                {
                    if (num > mid) sum += mid;
                    else sum += num;

                    if (sum > int.MaxValue) break;
                }
                if (sum > target) hi = mid;
                else if (sum < target) lo = mid + 1;
                else return mid;

                long diff = Math.Abs((long)target - sum);
                if (diff <= minDiff)
                {
                    if (diff == minDiff) result = Math.Min(result, mid);
                    else result = mid;

                    minDiff = diff;
                }
            }

            return result;
        }
    }
}
