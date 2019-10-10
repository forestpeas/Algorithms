namespace Algorithms.LeetCode
{
    /* 334. Increasing Triplet Subsequence
     * 
     * Given an unsorted array return whether an increasing subsequence of length 3 exists or not in the array.
     * 
     * Formally the function should:
     * 
     * Return true if there exists i, j, k
     * such that arr[i] < arr[j] < arr[k] given 0 ≤ i < j < k ≤ n-1 else return false.
     * Note: Your algorithm should run in O(n) time complexity and O(1) space complexity.
     * 
     * Example 1:
     * 
     * Input: [1,2,3,4,5]
     * Output: true
     * 
     * Example 2:
     * 
     * Input: [5,4,3,2,1]
     * Output: false
     */
    public class IncreasingTripletSubsequence
    {
        public bool IncreasingTriplet(int[] nums)
        {
            // arr[i] < arr[j] < arr[k]
            // a is candidate for arr[i].
            // b is candidate for arr[j].
            // test cases:
            // 6, 7, 1, 2, 3
            // 6, 7, 1, 8, 3
            int a = int.MaxValue;
            int b = int.MaxValue;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] > b) return true;
                if (nums[i] > a)
                {
                    b = nums[i];
                }
                else
                {
                    a = nums[i];
                }
            }
            return false;
        }
    }
}
