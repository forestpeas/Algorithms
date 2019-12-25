using System.Linq;

namespace Algorithms.LeetCode
{
    /* 1283. Find the Smallest Divisor Given a Threshold
     * 
     * Given an array of integers nums and an integer threshold, we will choose a positive integer divisor
     * and divide all the array by it and sum the result of the division.
     * Find the smallest divisor such that the result mentioned above is less than or equal to threshold.
     * Each result of division is rounded to the nearest integer greater than or equal to that element.
     * (For example: 7/3 = 3 and 10/2 = 5).
     * 
     * It is guaranteed that there will be an answer.
     * 
     * Example 1:
     * 
     * Input: nums = [1,2,5,9], threshold = 6
     * Output: 5
     * Explanation: We can get a sum to 17 (1+2+5+9) if the divisor is 1. 
     * If the divisor is 4 we can get a sum to 7 (1+1+2+3) and if the divisor is 5 the sum will be 5 (1+1+1+2). 
     * 
     * Example 2:
     * 
     * Input: nums = [2,3,5,7,11], threshold = 11
     * Output: 3
     * 
     * Example 3:
     * 
     * Input: nums = [19], threshold = 5
     * Output: 4
     */
    public class Find_the_Smallest_Divisor_Given_a_Threshold
    {
        public int SmallestDivisor(int[] nums, int threshold)
        {
            // Binary search.
            int lo = 1;
            int hi = nums.Max() + 1;
            while (lo < hi)
            {
                int mid = lo + (hi - lo) / 2;
                int sum = 0;
                foreach (int num in nums)
                {
                    sum += (num + mid - 1) / mid;
                }

                if (sum > threshold) lo = mid + 1;
                else hi = mid;
            }
            return lo;
        }
    }
}
