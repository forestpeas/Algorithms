using System.Collections.Generic;

namespace Algorithms.LeetCode
{
    /* 377. Combination Sum IV
     * 
     * Given an integer array with all positive numbers and no duplicates, find the number of possible combinations
     * that add up to a positive integer target.
     * 
     * Example:
     * 
     * nums = [1, 2, 3]
     * target = 4
     * 
     * The possible combination ways are:
     * (1, 1, 1, 1)
     * (1, 1, 2)
     * (1, 2, 1)
     * (1, 3)
     * (2, 1, 1)
     * (2, 2)
     * (3, 1)
     * 
     * Note that different sequences are counted as different combinations.
     * 
     * Therefore the output is 7.
     * 
     * Follow up:
     * What if negative numbers are allowed in the given array?
     * How does it change the problem?
     * What limitation we need to add to the question to allow negative numbers?
     */
    public class Combination_Sum_IV
    {
        public int CombinationSum4(int[] nums, int target)
        {
            // Recursion with memoization.
            var mem = new Dictionary<int, int>();
            return Combination(target);

            int Combination(int targetSum)
            {
                if (targetSum < 0) return 0;
                if (targetSum == 0) return 1;
                if (mem.ContainsKey(targetSum)) return mem[targetSum];

                int result = 0;
                for (int i = 0; i < nums.Length; i++)
                {
                    result += Combination(targetSum - nums[i]); // Let nums[i] be in front.
                }

                mem.Add(targetSum, result);
                return result;
            }
        }

        public int CombinationSum4_DP(int[] nums, int target)
        {
            // Similar to the O(n) space DP solution of "518. Coin Change 2".
            // "518. Coin Change 2" is combination and this problem is permutation.
            // The difference is that in "518. Coin Change 2", we choose a certain coin
            // and try to make up the sum with this coin, then we won't choose this coin
            // again, for example, dp[4] first comes from "1 + [1,1,1]", then from "2 + [1,1]",
            // (only choosing 1 and only choosing 2), so the traversal of coins is the outer loop.
            // But in this problem, we choose a number and check all the previous possibilities,
            // for example, when we want to calculate dp[3], dp[2] already contains [1,1] and [2].
            // We first check "1 and dp[2]" (choosing 1), then we check "2 and dp[1]" (choosing 2),
            // so the traversal of nums is the inner loop.
            int[] dp = new int[target + 1];

            dp[0] = 1;

            for (int j = 1; j <= target; j++)
            {
                foreach (int num in nums)
                {
                    if (j - num >= 0) dp[j] += dp[j - num];
                }
            }

            return dp[target];
        }
    }
}
