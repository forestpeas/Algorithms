using System.Linq;

namespace Algorithms.LeetCode
{
    /* 1289. Minimum Falling Path Sum II
     * 
     * Given a square grid of integers arr, a falling path with non-zero shifts is a choice of exactly one
     * element from each row of arr, such that no two elements chosen in adjacent rows are in the same column.
     * 
     * Return the minimum sum of a falling path with non-zero shifts.
     * 
     * Example 1:
     * 
     * Input: arr = [[1,2,3],[4,5,6],[7,8,9]]
     * Output: 13
     * Explanation: 
     * The possible falling paths are:
     * [1,5,9], [1,5,7], [1,6,7], [1,6,8],
     * [2,4,8], [2,4,9], [2,6,7], [2,6,8],
     * [3,4,8], [3,4,9], [3,5,7], [3,5,9]
     * The falling path with the smallest sum is [1,5,7], so the answer is 13.
     */
    public class Minimum_Falling_Path_Sum_II
    {
        public int MinFallingPathSum(int[][] arr)
        {
            // dp[j] is the minimum sum of a falling path with arr[i][j] being the chosen element from row i.
            if (arr.Length == 1) return arr[0][0];
            int n = arr.Length;
            int[] dp = new int[n];
            for (int i = 0; i < n; i++)
            {
                int min = int.MaxValue, secondMin = int.MaxValue;
                for (int j = 0; j < n; j++)
                {
                    if (dp[j] < secondMin)
                    {
                        if (min > dp[j])
                        {
                            secondMin = min;
                            min = dp[j];
                        }
                        else
                        {
                            secondMin = dp[j];
                        }
                    }
                }

                int[] nextDp = new int[n];
                for (int j = 0; j < n; j++)
                {
                    if (dp[j] != min) nextDp[j] = arr[i][j] + min;
                    else nextDp[j] = arr[i][j] + secondMin;
                }
                dp = nextDp;
            }

            return dp.Min();
        }
    }
}
