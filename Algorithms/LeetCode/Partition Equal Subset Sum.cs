using System.Linq;

namespace Algorithms.LeetCode
{
    /* 416. Partition Equal Subset Sum
     * 
     * Given a non-empty array containing only positive integers, find if the array can be partitioned
     * into two subsets such that the sum of elements in both subsets is equal.
     * 
     * Note:
     * Each of the array element will not exceed 100.
     * The array size will not exceed 200.  
     * 
     * Example 1:
     * 
     * Input: [1, 5, 11, 5]
     * Output: true
     * Explanation: The array can be partitioned as [1, 5, 5] and [11].
     *  
     * Example 2:
     * 
     * Input: [1, 2, 3, 5]
     * Output: false
     * Explanation: The array cannot be partitioned into equal sum subsets.
     */
    public class PartitionEqualSubsetSum
    {
        public bool CanPartition(int[] nums)
        {
            // The problem is equal to finding if there is a subset such that the sum of elements in it
            // is target = sum / 2.
            // dp[i, j] means whether there can be a sum j from a certain subset in nums[0...i].
            // If dp[i - 1, j] == true, apparently dp[i, j] is also true, which means we do not include
            // nums[i] in the sum of j.
            // Or else, we must try to include nums[i], and we check whether dp[i - 1, j - nums[i - 1]]
            // is true.
            int sum = nums.Sum();
            if (sum % 2 == 1) return false;
            int target = sum / 2;
            bool[,] dp = new bool[nums.Length + 1, target + 1];

            dp[0, 0] = true;

            for (int i = 1; i <= nums.Length; i++)
            {
                dp[i, 0] = true;
            }

            for (int i = 1; i <= nums.Length; i++)
            {
                for (int j = 1; j <= target; j++)
                {
                    dp[i, j] = dp[i - 1, j] || (j >= nums[i - 1] && dp[i - 1, j - nums[i - 1]]);
                }
            }

            return dp[nums.Length, target];
        }

        public bool CanPartition1(int[] nums)
        {
            // The above solution can be optimized to a single dimensional array.
            int sum = nums.Sum();
            if (sum % 2 == 1) return false;
            int target = sum / 2;
            bool[] dp = new bool[target + 1];

            dp[0] = true;

            for (int i = 0; i < nums.Length; i++)
            {
                // From right to left because the index j - nums[i] is on the left of j. 
                // Use left elements to update right elements so that the previous state
                // we need won't be affected.
                // When j < nums[i], the states stays the same as previous bacause including
                // nums[i] in sum does no good.
                for (int j = target; j >= nums[i]; j--)
                {
                    dp[j] = dp[j] || dp[j - nums[i]];
                }
            }

            return dp[target];
        }
    }
}
