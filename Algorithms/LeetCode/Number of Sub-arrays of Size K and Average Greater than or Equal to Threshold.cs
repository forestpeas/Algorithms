namespace Algorithms.LeetCode
{
    /* 1343. Number of Sub-arrays of Size K and Average Greater than or Equal to Threshold
     * 
     * Given an array of integers arr and two integers k and threshold.
     * Return the number of sub-arrays of size k and average greater than or equal to threshold.
     * 
     * Example 1:
     * 
     * Input: arr = [2,2,2,2,5,5,5,8], k = 3, threshold = 4
     * Output: 3
     * Explanation: Sub-arrays [2,5,5],[5,5,5] and [5,5,8] have averages 4, 5 and 6 respectively.
     * All other sub-arrays of size 3 have averages less than 4 (the threshold).
     * 
     * Constraints:
     * 1 <= arr[i] <= 10^4
     * 1 <= k <= arr.length
     */
    public class Number_of_Sub_arrays_of_Size_K_and_Average_Greater_than_or_Equal_to_Threshold
    {
        public int NumOfSubarrays(int[] arr, int k, int threshold)
        {
            // Maintain a sliding window of fixed length k.
            int result = 0;
            for (int i = 0, sum = 0; i < arr.Length; i++)
            {
                sum += arr[i];
                if (i < k - 1) continue;
                if (i - k >= 0) sum -= arr[i - k];
                if (sum / k >= threshold) result++;
            }
            return result;
        }
    }
}
