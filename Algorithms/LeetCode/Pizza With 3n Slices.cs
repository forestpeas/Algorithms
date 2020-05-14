using System;
using System.Linq;

namespace Algorithms.LeetCode
{
    /* 1388. Pizza With 3n Slices
     * There is a pizza with 3n slices of varying size, you and your friends will take slices of pizza
     * as follows:
     * You will pick any pizza slice.
     * Your friend Alice will pick next slice in anti clockwise direction of your pick. 
     * Your friend Bob will pick next slice in clockwise direction of your pick.
     * Repeat until there are no more slices of pizzas.
     * 
     * Sizes of Pizza slices is represented by circular array slices in clockwise direction.
     * Return the maximum possible sum of slice sizes which you can have.
     * 
     * Example 1:
     * https://leetcode.com/problems/pizza-with-3n-slices/ 
     * Input: slices = [1,2,3,4,5,6]
     * Output: 10
     * Explanation: Pick pizza slice of size 4, Alice and Bob will pick slices with size 3 and 5
     * respectively. Then Pick slices with size 6, finally Alice and Bob will pick slice of size 2
     * and 1 respectively. Total = 4 + 6.
     * 
     * Example 2:
     * 
     * Input: slices = [8,9,8,6,1,1]
     * Output: 16
     * Output: Pick pizza slice of size 8 in each turn. If you pick slice with size 9 your partners
     * will pick slices of size 8.
     * 
     * Example 3:
     * 
     * Input: slices = [4,1,2,5,8,3,1,9,7]
     * Output: 21
     * 
     * Example 4:
     * 
     * Input: slices = [3,1,2]
     * Output: 3 
     * 
     * Constraints:
     * 
     * 1 <= slices.length <= 500
     * slices.length % 3 == 0
     * 1 <= slices[i] <= 1000
     */
    public class Pizza_With_3n_Slices
    {
        public int MaxSizeSlices(int[] slices)
        {
            // By studying the pattern of the operations, we can find out that the problem is
            // equivalent to: Given an integer array with size 3N, select N integers with maximum
            // sum and any selected integers are not next to each other in the array. So it is
            // similar to "213. House Robber II". The difference is that this problem requires
            // that the number of chosen slices should be exactly n/3, similar to the knapsack problem.
            // dp[i,j] = max(dp[i-1, j], slices[i] + dp[i-2, j-1])
            // dp[i,j] is max sum of slices within [0...i], given that we can choose at most j slices.
            return Math.Max(
                Core(slices.Skip(1).ToArray(), slices.Length / 3),
                Core(slices.Take(slices.Length - 1).ToArray(), slices.Length / 3));
        }

        public int Core(int[] slices, int numAllowed)
        {
            int[,] dp = new int[slices.Length, numAllowed + 1];

            for (int i = 0; i < slices.Length; i++)
            {
                for (int j = 1; j <= numAllowed; j++)
                {
                    int tmp1 = i - 1 < 0 ? 0 : dp[i - 1, j];
                    int tmp2 = i - 2 < 0 ? 0 : dp[i - 2, j - 1];
                    dp[i, j] = Math.Max(tmp1, slices[i] + tmp2);
                }
            }

            return dp[slices.Length - 1, numAllowed];
        }
    }
}
